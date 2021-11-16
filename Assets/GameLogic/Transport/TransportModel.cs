using System;
using GameLogic.Manufacture;
using UnityEngine;

namespace GameLogic.Transport
{
    public interface ITransportModel
    {
        public event Action OnCreateConnection;
        
        public IManufactureModel SenderModel { get; }
        public IManufactureModel ReceiverModel { get; }
        public Vector3 SenderPosition { get; set; }
        
        public Vector3 ReceiverPosition { get; set; }

        public void AddSenderModel(IManufactureModel senderModel);

        public void AddReceiverModel(IManufactureModel receiverModel);

        public bool TransportEquals(ITransportModel other);
        public void OnDestroy();
    }
    public class TransportModel : ITransportModel, ITickable
    {
        public event Action OnCreateConnection;
        public IManufactureModel SenderModel => senderModel;
        public IManufactureModel ReceiverModel => receiverModel;

        private readonly TransportationService transportationService;
        private IManufactureModel senderModel;
        private IManufactureModel receiverModel;
        private Vector3 senderPosition;
        private float distance;
        private float timer;
        private float transportationSpeed = 5;
        private bool isConnected;

        public TransportModel(TransportationService transportationService)
        {
            this.transportationService = transportationService;
        }

        public Vector3 SenderPosition { get => senderPosition;
            set
            {
                if(senderPosition == value) return;
                senderPosition = value;
                OnCreateConnection?.Invoke();
            } }

        public Vector3 ReceiverPosition { get; set; }

        public void AddSenderModel(IManufactureModel senderModel)
        {
            this.senderModel = senderModel;

            SenderPosition = senderModel.ManufactureData.Position;

        }

        public void AddReceiverModel(IManufactureModel receiverModel)
        {
            this.receiverModel = receiverModel;

            ReceiverPosition = receiverModel.ManufactureData.Position;
            
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
            if(senderModel.ResourceAmount < 1) return;
            timer += Time.deltaTime;
            if (timer > distance / transportationSpeed)
            {
                timer = 0f;
                senderModel.ResourceAmount--;
                receiverModel.ManufactureData.AddDemandResources(senderModel.ManufactureData.ProducingResource);
            }
        }

        public void OnDestroy()
        {
            transportationService.OnDestroyBridge(this);
        }

        public bool TransportEquals(ITransportModel other)
        {
            if (other == null) return false;

            if (other.ReceiverModel == null ||
                (other.SenderModel.ManufactureData.ProducingResource ==
                 this.senderModel.ManufactureData.ProducingResource &&
                 other.ReceiverModel.ManufactureData.ProducingResource ==
                 this.receiverModel.ManufactureData.ProducingResource))
            {
                return true;
            }
            return false;
        }
    }
}