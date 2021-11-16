using UnityEngine;

namespace GameLogic.Transport
{
    public interface ITransportController
    {
        
    }
    
    public class TransportController: ITransportController
    {
        private readonly ITransportModel model;
        private readonly ITransportView view;

        public TransportController(ITransportModel model, ITransportView view)
        {
            this.model = model;
            this.view = view;
            
            model.OnCreateConnection += ModelOnCreateConnection;
            
            model.OnDestroy += ModelOnDestroy;
            
            view.OnDestroy += ViewOnDestroy;
        }

        private void ModelOnDestroy()
        {
            Unsubscribe();
            view.Destroy();
        }

        private void ViewOnDestroy()
        {
            model.Destroy();
        }

        private void ModelOnCreateConnection()
        {
            view.SenderPosition = model.SenderPosition;
            view.ReceiverPosition = model.ReceiverPosition;
        }

        private void Unsubscribe()
        {
            model.OnCreateConnection -= ModelOnCreateConnection;
            model.OnDestroy -= ModelOnDestroy;
            view.OnDestroy -= ViewOnDestroy;
        }
    }
}