using UnityEngine;

namespace Refinery
{
    public interface IRefineryViewFactory
    {
        IRefineryView View { get; }
    }
    
    [CreateAssetMenu(fileName = "RefineryViewFactory", menuName = "SO/RefineryViewFactory", order = 1)]
    public class RefineryViewFactory : ScriptableObject
    {
        public RefineryView refineryView;
        
        public IRefineryView View { get; private set; }

        public void Initiate()
        {
            var instance = Instantiate(refineryView);
            View = instance.GetComponent<IRefineryView>();
            instance.transform.position = new Vector3(0, 0, 0);
        }
    }

    public interface IRefineryControllerFactory
    {
        IRefineryController Controller { get; }
    }

    public class RefineryControllerFactory : IRefineryControllerFactory
    {
        public IRefineryController Controller { get; }

        public RefineryControllerFactory(IRefineryModel model, IRefineryView view)
        {
            Controller = new RefineryController(model, view);
        }
    }

    public interface IRefineryModelFactory
    {
        IRefineryModel Model { get; }
    }

    public class RefineryModelFactory : IRefineryModelFactory
    {
        public IRefineryModel Model { get; }

        public RefineryModelFactory()
        {
            Model = new RefineryModel();
        }
    }
}