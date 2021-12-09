using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IResourceStorageViewFactory
    {
        IResourceStorageView ResourceStorageView { get; }
    }
    [CreateAssetMenu(fileName = "ResourceStorageViewFactory", menuName = "SO/ResourceStorageViewFactory", order = 0)]
    public class ResourceStorageViewFactory : ScriptableObject, IResourceStorageViewFactory
    {
        [SerializeField] private ResourceStorageView resourceStorageView;
        
        public IResourceStorageView ResourceStorageView { get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(resourceStorageView, parent);
            ResourceStorageView = instance.GetComponent<IResourceStorageView>();
        }
    }
}