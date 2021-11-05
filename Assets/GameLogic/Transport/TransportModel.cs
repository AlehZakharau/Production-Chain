using System;
using GameLogic.ProductionPoint;
using UnityEngine;

namespace DefaultNamespace.Transport
{
    public interface ITransportModel
    {
        public event Action<IManufactureModel, ITransportModel> OnDestroy;
        public event Action OnCreateBridge;
        public Vector3 SenderPosition { get; set; }
        
        public Vector3 ReceiverPosition { get; set; }
        
        public void Transportation();

        public void CreateBridge();

        public void OnDestroyBridge();
    }
    public class TransportModel : ITransportModel
    {
        private readonly IManufactureModel senderModel;
        private readonly IManufactureModel receiverModel;
        private readonly float distance;
        private float timer;
        private float transportationSpeed = 5;
        public TransportModel(IManufactureModel sender, IManufactureModel receiver)
        {
            senderModel = sender;
            receiverModel = receiver;

            SenderPosition = sender.ManufactureData.Position;
            ReceiverPosition = receiver.ManufactureData.Position;
            
            distance = Vector3.Distance(SenderPosition, ReceiverPosition);

            Debug.Log($"Sender: {sender.ManufactureData.ProducingResource} " +
                      $"Receiver: {receiver.ManufactureData.ProducingResource}");
        }

        public event Action<IManufactureModel, ITransportModel> OnDestroy;
        public event Action OnCreateBridge;
        public Vector3 SenderPosition { get; set; }

        public Vector3 ReceiverPosition { get; set; }

        public void Tick()
        {
            Transportation();
        }

        public void Transportation()
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

        public void CreateBridge()
        {
            OnCreateBridge?.Invoke();
        }

        public void OnDestroyBridge()
        {
            OnDestroy?.Invoke(senderModel, this);
        }
    }
}