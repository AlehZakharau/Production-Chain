using DefaultNamespace.Transport;
using UnityEngine;

namespace GameLogic.ProductionPoint
{
    public interface IManufactureViewFactory
    {
        IManufactureView View { get; }
    }
    
    [CreateAssetMenu(fileName = "ProductionPointViewFactory", 
        menuName = "SO/ProductionPointViewFactory", order = 0)]
    public class ManufactureViewFactory : ScriptableObject, IManufactureViewFactory
    {
        [SerializeField]private ManufactureView productionView;
        
        public IManufactureView View { get; private set; }
    
        public void Initiate(Transform parent)
        {
            var instance = Instantiate(productionView);
            View = instance.GetComponent<IManufactureView>();
            instance.transform.position = new Vector3(0, 0, 0);
            instance.transform.SetParent(parent);
        }
    }

    public interface IManufactureModelFactory
    {
        IManufactureModel Model { get; }
    }
    
    public class ManufactureModelFactory : IManufactureModelFactory
    {
        public IManufactureModel Model { get; }
        public ITickable Tickable { get; }

        public ManufactureModelFactory(ManufactureData spec, TransportationService transportationService)
        {
            var model = new ManufactureModel(spec, transportationService);
            Model = model;
            Tickable = model;

        }
    }

    public interface IManufactureControllerFactory
    {
        IManufactureController Controller { get; }
    }
    
    public class ManufactureControllerFactory : IManufactureControllerFactory
    {
        public IManufactureController Controller { get; }
    
        public ManufactureControllerFactory(IManufactureModel model,
            IManufactureView view)
        {
            Controller = new ManufactureController(model, view);
        }
    }
}