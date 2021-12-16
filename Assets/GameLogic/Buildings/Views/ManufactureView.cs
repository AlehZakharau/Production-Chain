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
        [SerializeField] private SpriteRenderer resourceIconActive;
        [SerializeField] private SpriteRenderer resourceIconDeActive;

        private ResourceType resourceType;

        public ResourceType ResourceType
        {
            get => resourceType;
            set
            {
                resourceType = value;
                resourceIconActive.sprite = resourceIcons.resourceIconsA[resourceType];
                resourceIconDeActive.sprite = resourceIcons.resourceIconsDA[resourceType];
            }
        }
    }
}