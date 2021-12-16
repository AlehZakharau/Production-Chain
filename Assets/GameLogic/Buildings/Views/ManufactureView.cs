using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IManufactureView
    {
        public ResourceType ResourceType { get; set; }
    }
    public class ManufactureView : MonoBehaviour, IManufactureView
    {
        [SerializeField] private ResourceIcons resourceIcons;
        
        public ResourceType ResourceType { get; set; }
    }
}