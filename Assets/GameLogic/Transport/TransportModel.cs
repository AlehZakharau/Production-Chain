// using System;
// using DefaultNamespace.ProductionPoint;
// using Extractive;
// using Refinery;
// using UnityEngine;
//
// namespace DefaultNamespace.Transport
// {
//     public interface ITransportModel
//     {
//         public event Action<IProductionPointModel, ITransportModel> OnDestroy;
//         public event Action OnCreateBridge;
//         public Vector3 SenderPosition { get; set; }
//         
//         public Vector3 ReceiverPosition { get; set; }
//         
//         public void Transportation();
//
//         public void CreateBridge();
//
//         public void OnDestroyBridge();
//     }
//     public class TransportModel : ITransportModel
//     {
//         private readonly IProductionPointModel senderModel;
//         private readonly IProductionPointModel receiverModel;
//         private readonly float distance;
//         private float timer;
//         private float transportationSpeed = 5;
//         public TransportModel(IProductionPointModel sender, IProductionPointModel receiver)
//         {
//             senderModel = sender;
//             receiverModel = receiver;
//
//             SenderPosition = sender.Position;
//             ReceiverPosition = receiver.Position;
//             
//             distance = Vector3.Distance(SenderPosition, ReceiverPosition);
//
//             Debug.Log($"Sender: {sender.ProducingResourceType} Receiver: {receiver.ProducingResourceType}");
//         }
//
//         public event Action<IProductionPointModel, ITransportModel> OnDestroy;
//         public event Action OnCreateBridge;
//         public Vector3 SenderPosition { get; set; }
//
//         public Vector3 ReceiverPosition { get; set; }
//
//         public void Tick()
//         {
//             Transportation();
//         }
//
//         public void Transportation()
//         {
//             if(senderModel.ProducingResource < 1) return;
//             timer += Time.deltaTime;
//             if (timer > distance / transportationSpeed)
//             {
//                 timer = 0f;
//                 senderModel.ProducingResource--;
//                 receiverModel.AddDemandResources(senderModel.ProducingResourceType);
//             }
//         }
//
//         public void CreateBridge()
//         {
//             OnCreateBridge?.Invoke();
//         }
//
//         public void OnDestroyBridge()
//         {
//             OnDestroy?.Invoke(senderModel, this);
//         }
//     }
// }