using GameLogic;
using UnityEngine;

namespace DefaultNamespace.ProductionPoint
{
    // public interface IProductionPointViewFactory
    // {
    //     IProductionPointView View { get; }
    // }
    //
    // [CreateAssetMenu(fileName = "ProductionPointViewFactory", 
    //     menuName = "SO/ProductionPointViewFactory", order = 0)]
    // public class ProductionPointViewFactory : ScriptableObject, IProductionPointViewFactory
    // {
    //     public ProductionPointView productionView;
    //     
    //     public IProductionPointView View { get; private set; }
    //
    //     public void Initiate()
    //     {
    //         var instance = Instantiate(productionView);
    //         View = instance.GetComponent<IProductionPointView>();
    //         instance.transform.position = new Vector3(0, 0, 0);
    //     }
    // }

    public interface IProductionPointModelFactory
    {
        IProductionPointModel Model { get; }
    }
    
    public class ProductionPointModelFactory : IProductionPointModelFactory
    {
        public IProductionPointModel Model { get; }

        public ProductionPointModelFactory(ProductionPointSpec spec)
        {
            Model = new ProductionPointModel(spec);
        }
    }

    // public interface IProductionPointControllerFactory
    // {
    //     IProductionPointController Controller { get; }
    // }
    //
    // public class ProductionPointControllerFactory : IProductionPointControllerFactory
    // {
    //     public IProductionPointController Controller { get; }
    //
    //     public ProductionPointControllerFactory(IProductionPointModel model,
    //         IProductionPointView view)
    //     {
    //         Controller = new ProductionPointController(model, view);
    //     }
    // }
}