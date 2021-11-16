using System.Collections.Generic;
using GameLogic.Manufacture;

namespace GameLogic.Transport
{
    public class TransportationService
    {
        private readonly Tick tick;
        private readonly TransportViewFactory transportViewFactory;

        private IManufactureModel sender;
        private IManufactureModel receiver;
        
        private readonly Dictionary<ITransportModel, ITickable> transports = new Dictionary<ITransportModel, ITickable>();

        private ITransportModel currentTransport;
        private bool isCurrentConnected;

        public TransportationService(TransportViewFactory transportViewFactory, Tick tick)
        {
            this.tick = tick;
            this.transportViewFactory = transportViewFactory;
        }

        public bool AddManufactureModel(IManufactureModel manufactureModel)
        {
            if (sender == null)
            {
                sender = manufactureModel;
                return true;
            }
            else
            {
                if (receiver != null ||
                    sender.ManufactureData.ProducingResource == manufactureModel.ManufactureData.ProducingResource)
                {
                    sender = null;
                    receiver = null;
                    return false;
                }
                receiver = manufactureModel;
                {
                    if (CheckResourceMatch() && CheckTransport() < 2)
                    {
                        CreateTransport(sender, receiver);

                        sender = null;
                        receiver = null;
                        currentTransport = null;
                        return true;
                    }
                }
                sender = null;
                receiver = null;
                return false;
            }
        }

        private void CreateTransport(IManufactureModel sender, IManufactureModel receiver)
        {
            var transportModelFactory = new TransportModelFactory( this);
            tick.Tickable.Add(transportModelFactory.Tick);
            var model = transportModelFactory.Model;
            transports.Add(model, transportModelFactory.Tick);
            currentTransport = model;
            
            transportViewFactory.Initiate();
            var view = transportViewFactory.View;

            var transportControllerFactory = new TransportControllerFactory(model, view);
            var controller = transportControllerFactory.Controller;
            
            model.AddManufactureModel(sender, receiver);
        }

        public void OnDestroyBridge(ITransportModel transportModel)
        {
            tick.Tickable.Remove(transports[transportModel]);
            transports.Remove(transportModel);
        }

        private bool CheckResourceMatch()
        {
            return receiver.ManufactureData.DemandProductionResource.Contains(sender.ManufactureData.ProducingResource) ||
                   receiver.ManufactureData.DemandUpgradeResources.
                       Contains(sender.ManufactureData.ProducingResource);
        }

        private int CheckTransport()
        {
            var index = 0;
            foreach (var transport in transports)
            {
                if (transport.Key.TransportEquals(currentTransport))
                {
                    index++;
                }
            }
            return index;
        }
    }
}