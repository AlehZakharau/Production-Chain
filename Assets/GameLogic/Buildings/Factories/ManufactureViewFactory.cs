using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IManufactureViewFactory
    {
        public IManufactureView ManufactureView { get; }
    }
    [CreateAssetMenu(fileName = "ManufactureViewFactory", 
        menuName = "Factories/ManufactureViewFactory", order = 0)]
    public class ManufactureViewFactory : ScriptableObject, IManufactureViewFactory
    {
        [SerializeField] private ManufactureView manufactureView;
        
        public IManufactureView ManufactureView { get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(manufactureView, parent);
            ManufactureView = instance.GetComponent<IManufactureView>();
        }
    }
}