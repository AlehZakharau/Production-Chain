using System;
using System.Collections.Generic;
using DefaultNamespace.ProductionPoint;
using GameLogic.ProductionPoint;
using UnityEngine;

namespace DefaultNamespace.Transport
{
    public class TransportationService
    {
        //[SerializeField] private ProductionPointInitialize productionInit;

        [SerializeField] private TransportViewFactory transportViewFactory;
        // private ResourceType sentResource;
        // private ResourceType receivedResource;

        private IManufactureModel senderPoint;
        private IManufactureModel receiverPoint;

        private readonly List<IManufactureModel> senders = new List<IManufactureModel>();
        private readonly List<ITransportModel> transports = new List<ITransportModel>();

        // public event Action OnCancel;
        // public event Action OnSuccess;
            

        // private void Start()
        // {
        //     foreach (var modelFactory in productionInit.ProductionModelFactories)
        //     {
        //         modelFactory.Model.OnClick += CallTransportService;
        //     }
        // }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Cancel();
            }

            foreach (var transport in transports)
            {
                transport.Transportation();
            }
        }


        public void CallTransportService(IManufactureModel productionModel)
        {
            Debug.Log($"Transport service get a message");
            if (senderPoint == null && !CheckSenders(productionModel))
            {
                senderPoint = productionModel;
                return;
            }

            if (receiverPoint != null || senderPoint == productionModel) return;
            receiverPoint = productionModel;
            // if (CheckResourceMatch())
            // {
            //     Success();
            // }
            // else
            // {
            //     Cancel();
            //     
            // }
        }

        private void Success()
        {
            senders.Add(senderPoint);
            
            var transportModelFactory = new TransportModelFactory(
                senderPoint, receiverPoint);
            var model = transportModelFactory.Model;
            transports.Add(model);
            model.OnDestroy += OnDestroyBridge;
            
            transportViewFactory.Initiate();
            var view = transportViewFactory.View;

            var transportControllerFactory = new TransportControllerFactory(model, view);
            var controller = transportControllerFactory.Controller;
            
            model.CreateBridge();
            
            senderPoint = null;
            receiverPoint = null;
        }

        private void Cancel()
        {
            senderPoint = null;
            receiverPoint = null;
        }

        private void OnDestroyBridge(IManufactureModel sender, ITransportModel transportModel)
        {
            senders.Remove(sender);
            transports.Remove(transportModel);
            transportModel.OnDestroy -= OnDestroyBridge;
        }

        // private bool CheckResourceMatch()
        // {
        //     return receiverPoint.DemandResources.ContainsKey(senderPoint.ProducingResourceType) ||
        //            receiverPoint.ProductionPointUpdateModel.DemandUpdateResources.
        //                ContainsKey(senderPoint.ProducingResourceType);
        // }

        private bool CheckSenders(IManufactureModel sender)
        {
            return senders.Contains(sender);
        }
    }
}