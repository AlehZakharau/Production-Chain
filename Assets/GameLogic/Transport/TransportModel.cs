﻿using System;
using GameLogic.Buildings.Interfaces;
using GameLogic.Buildings.Models.ManufactoryModels;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GameLogic.Transport
{
    public interface ITransportModel
    {
        public event Action OnConsumption;
        public event Action OnStopConsumption;
        public event Action OnDestroy;
        public event Action OnCreateConnection;
        public Vector3 SenderPosition { get; set; }
        
        public Vector3 ReceiverPosition { get; set; }

        public void AddModels(IManufactureModel sender, IResourceStorage receiver);
        public void Destroy();
    }
    public class TransportModel : ITransportModel, ITickable
    {
        public event Action OnConsumption;
        public event Action OnStopConsumption;
        public event Action OnDestroy;
        public event Action OnCreateConnection;

        private readonly TransportationService transportationService;
        private IManufactureModel senderModel;
        private IResourceStorage receiver;
        private Vector3 senderPosition;
        private Vector3 receiverPosition;
        private float distance;
        private float timer;
        private float transportationSpeed = 5;
        private bool isConnected;

        public TransportModel(TransportationService transportationService)
        {
            this.transportationService = transportationService;
        }

        public Vector3 SenderPosition { get; set; }

        public Vector3 ReceiverPosition
        {
            get => receiverPosition;
            set
            {
                if(receiverPosition == value) return;
                receiverPosition = value;
                OnCreateConnection?.Invoke();
            }
        }

        public void AddModels(IManufactureModel sender, IResourceStorage receiver)
        {
            AddSenderModel(sender);
            AddReceiverModel(receiver);
        }
        
        private void AddSenderModel(IManufactureModel senderModel)
        {
            this.senderModel = senderModel;
        
            SenderPosition = senderModel.BuildingModel.Position;
        
        }
        
        private void AddReceiverModel(IResourceStorage receiver)
        {
            this.receiver = receiver;
        
            ReceiverPosition = receiver.BuildingModel.Position;
            
            distance = Vector3.Distance(SenderPosition, ReceiverPosition);
        
            isConnected = true;
        }

        public void Tick()
        {
            if (isConnected)
            {
                Transportation();
            }
        }

        private void Transportation()
        {
            timer += Time.deltaTime;
            if (timer > distance / transportationSpeed)
            {
                timer = 0f;
                if(senderModel.GetResourceAmount() < 1) return;
                var status = receiver.AddDemandResources(senderModel.ResourceType);
                if (status)
                {
                    senderModel.TransportingResource();
                    OnConsumption?.Invoke();
                }
                else
                {
                    OnStopConsumption?.Invoke();
                }
            }
        }

        public void Destroy()
        {
            OnDestroy?.Invoke();
            senderModel.IsSender = false;
            transportationService.OnDestroyBridge(this);
        }
    }
}