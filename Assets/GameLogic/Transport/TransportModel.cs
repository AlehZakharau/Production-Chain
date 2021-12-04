using System;
using GameLogic.Manufacture;
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
        
        //public IManufactureModel SenderModel { get; }
        //public IManufactureModel ReceiverModel { get; }
        public Vector3 SenderPosition { get; set; }
        
        public Vector3 ReceiverPosition { get; set; }

        //public void AddManufactureModel(IManufactureModel sender, IManufactureModel receiver);

        public bool TransportEquals(ITransportModel other);
        public void Destroy();
    }
    public class TransportModel : ITransportModel, ITickable
    {
        public event Action OnConsumption;
        public event Action OnStopConsumption;
        public event Action OnDestroy;
        public event Action OnCreateConnection;
        //public IManufactureModel SenderModel => senderModel;
        //public IManufactureModel ReceiverModel => receiverModel;

        private readonly TransportationService transportationService;
        //private IManufactureModel senderModel;
        //private IManufactureModel receiverModel;
        //private Vector3 senderPosition;
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

        // public void AddManufactureModel(IManufactureModel sender, IManufactureModel receiver)
        // {
        //     AddSenderModel(sender);
        //     AddReceiverModel(receiver);
        // }
        //
        // private void AddSenderModel(IManufactureModel senderModel)
        // {
        //     this.senderModel = senderModel;
        //
        //     SenderPosition = senderModel.ManufactureData.Position;
        //
        // }
        //
        // private void AddReceiverModel(IManufactureModel receiverModel)
        // {
        //     this.receiverModel = receiverModel;
        //
        //     ReceiverPosition = receiverModel.ManufactureData.Position;
        //     
        //     distance = Vector3.Distance(SenderPosition, ReceiverPosition);
        //
        //     isConnected = true;
        // }

        public void Tick()
        {
            if (isConnected)
            {
                //Transportation();
            }
        }

        // private void Transportation()
        // {
        //     if(senderModel.ResourceAmount < 1) return;
        //     timer += Time.deltaTime;
        //     if (timer > distance / transportationSpeed)
        //     {
        //         timer = 0f;
        //         senderModel.ResourceAmount--;
        //         var status = receiverModel.ManufactureData.AddDemandResources(senderModel.ManufactureData.ResourceType);
        //         if (status)
        //         {
        //             OnConsumption?.Invoke();
        //         }
        //         else
        //         {
        //             OnStopConsumption?.Invoke();
        //         }
        //         
        //     }
        // }

        public void Destroy()
        {
            OnDestroy?.Invoke();
            transportationService.OnDestroyBridge(this);
        }

        public bool TransportEquals(ITransportModel other)
        {
            if (other == null) return false;
        
            // if (other.ReceiverModel == null ||
            //     (other.SenderModel.ManufactureData.ResourceType ==
            //      this.senderModel.ManufactureData.ResourceType &&
            //      other.ReceiverModel.ManufactureData.ResourceType ==
            //      this.receiverModel.ManufactureData.ResourceType))
            // {
            //     return true;
            // }
            return false;
        }
    }
}