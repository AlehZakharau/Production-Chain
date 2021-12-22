using System.Collections.Generic;
using GameLogic.Buildings.Interfaces;
using GameLogic.Buildings.Models.ManufactoryModels;

namespace GameLogic.Transport
{
    public class TransportationService
    {
        private readonly Tick tick;
        private readonly TransportViewFactory transportViewFactory;

        private IManufactureModel sender;
        private IResourceStorage receiver;
        
        private readonly Dictionary<ITransportModel, ITickable> transports = new Dictionary<ITransportModel, ITickable>();

        private ITransportModel currentTransport;
        private bool isCurrentConnected;

        public TransportationService(TransportViewFactory transportViewFactory)
        {
            this.transportViewFactory = transportViewFactory;
        }

        public bool CallTransportService(IManufactureModel sender, IResourceStorage receiver)
        {
            return this.sender == null ? AddManufactureModel(sender) : AddResourceStorage(receiver);
        }

        public bool CallTransportService(IResourceStorage receiver)
        {
            return sender != null && AddResourceStorage(receiver);
        }

        private bool AddManufactureModel(IManufactureModel manufactureModel)
        {
            if (sender == null)
            {
                sender = manufactureModel;
                return true;
            }
            ClearCurrentTransport();
            return false;
        }

        private bool AddResourceStorage(IResourceStorage resourceStorage)
        {
            if (receiver == null)
            {
                receiver = resourceStorage;
                if (receiver.CheckResource(sender.ResourceType))
                {
                    sender.IsSender = true;
                    CreateTransport(sender, receiver);
                    return true;
                }
            }
            ClearCurrentTransport();
            return false;
        }

        private void ClearCurrentTransport()
        {
            sender = null;
            receiver = null;
            currentTransport = null;
        }

        private void CreateTransport(IManufactureModel sender, IResourceStorage receiver)
        {
            var transportModelFactory = new TransportModelFactory( this);
            Tick.Tickable.Add(transportModelFactory.Tick);
            var model = transportModelFactory.Model;
            transports.Add(model, transportModelFactory.Tick);
            currentTransport = model;
            
            transportViewFactory.Initiate();
            var view = transportViewFactory.View;
        
            var transportControllerFactory = new TransportControllerFactory(model, view);
            var controller = transportControllerFactory.Controller;
            
            model.AddModels(sender, receiver);
        }

        public void OnDestroyBridge(ITransportModel transportModel)
        {
            Tick.Tickable.Remove(transports[transportModel]);
            transports.Remove(transportModel);
        }
    }
}