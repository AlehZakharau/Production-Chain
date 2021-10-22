namespace DefaultNamespace.Transport
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
            
            model.OnCreateBridge += ModelOnOnCreateBridge;
            
            view.OnDestroy += ViewOnDestroy;
        }

        private void ViewOnDestroy()
        {
            model.OnDestroyBridge();
            view.OnDestroy -= ViewOnDestroy;
        }

        private void ModelOnOnCreateBridge()
        {
            view.SenderPosition = model.SenderPosition;
            view.ReceiverPosition = model.ReceiverPosition;
            view.CreateBridge();
        }
    }
}