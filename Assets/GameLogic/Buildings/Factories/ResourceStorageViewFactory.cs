using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IResourceStorageViewFactory
    {
        IProduceView ProduceView { get; }
    }
    [CreateAssetMenu(fileName = "ResourceStorageViewFactory", 
        menuName = "Factories/ResourceStorageViewFactory", order = 0)]
    public class ResourceStorageViewFactory : ScriptableObject, IResourceStorageViewFactory
    {
        [SerializeField] private ProduceView produceView;
        
        public IProduceView ProduceView { get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(produceView, parent);
            ProduceView = instance.GetComponent<IProduceView>();
        }
    }
}