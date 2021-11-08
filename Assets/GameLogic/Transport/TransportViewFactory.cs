using GameLogic.Manufacture;
using UnityEngine;

namespace GameLogic.Transport
{
    public interface ITransportViewFactory
    {
        ITransportView View { get; }
    }
    
    [CreateAssetMenu(fileName = "TransportViewFactory", 
        menuName = "SO/TransportViewFactory", order = 0)]
    public class TransportViewFactory : ScriptableObject, ITransportViewFactory
    {
        public TransportView transportView;
            
        public ITransportView View { get; private set; }

        public void Initiate()
        {
            var instance = Instantiate(transportView);
            View = instance.GetComponent<ITransportView>();
            instance.transform.position = new Vector3(0, 0, 0);
        }
    }

    public interface ITransportModelFactory
    {
        ITransportModel Model { get; }
        ITickable Tick { get; }
    }

    public class TransportModelFactory : ITransportModelFactory
    {
        public ITransportModel Model { get; }
        public ITickable Tick { get; }

        public TransportModelFactory(TransportationService transportationService)
        {
            var model = new TransportModel(transportationService);
            Model = model;
            Tick = model;
        }
    }

    public interface ITransportControllerFactory
    {
        ITransportController Controller { get; }
    }
    
    public class TransportControllerFactory: ITransportControllerFactory
    {
        public ITransportController Controller { get; }

        public TransportControllerFactory(ITransportModel model,
            ITransportView view)
        {
            Controller = new TransportController(model, view);
        }
    }
}