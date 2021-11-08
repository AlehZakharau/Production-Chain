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
            
            view.OnDestroy += ViewOnDestroy;
        }

        private void ViewOnDestroy()
        {
            model.OnDestroy();
            view.OnDestroy -= ViewOnDestroy;
        }

        private void ModelOnCreateConnection()
        {
            view.SenderPosition = model.SenderPosition;
            view.ReceiverPosition = model.SenderPosition + new Vector3(0, -10, 0);
        }
    }
}