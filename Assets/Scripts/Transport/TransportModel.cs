using System;
using DefaultNamespace.ProductionPoint;
using Extractive;
using Refinery;
using UnityEngine;

namespace DefaultNamespace.Transport
{
    public interface ITransportModel
    {
        public event Action<IProductionPointModel, ITransportModel> OnDestroy;
        public event Action OnCreateBridge;
        public Vector3 SenderPosition { get; set; }
        
        public Vector3 ReceiverPosition { get; set; }

        public void Transportation();

        public void CreateBridge();

        public void OnDestroyBridge();
    }
    public class TransportModel : ITransportModel
    {
        private readonly IProductionPointModel senderModel;
        private readonly IProductionPointModel receiverModel;
        public TransportModel(IProductionPointModel sender, IProductionPointModel receiver)
        {
            senderModel = sender;
            receiverModel = receiver;

            SenderPosition = sender.Position;
            ReceiverPosition = receiver.Position;

            Debug.Log($"Sender: {sender.ProducingResourceType} Receiver: {receiver.ProducingResourceType}");
        }

        public event Action<IProductionPointModel, ITransportModel> OnDestroy;
        public event Action OnCreateBridge;
        public Vector3 SenderPosition { get; set; }

        public Vector3 ReceiverPosition { get; set; }

        public void Tick()
        {
            throw new System.NotImplementedException();
        }

        public void Transportation()
        {
            throw new NotImplementedException();
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