using GameLogic;
using TMPro;
using UnityEngine;

namespace GameLogic.ProductionPoint
{
    public interface IManufactureView
    {
        public ManufactureType ManufactureType { get; set; }
        public ResourceType ProducingResourceType { get; set; }
        public int ProducingResource { get; set; }
        public Vector3 Position { get; set; }
    }

    public class ManufactureView : MonoBehaviour, IManufactureView
    {
        [SerializeField] private TMP_Text manufactureTypeText;
        [SerializeField] private TMP_Text producingResourceText;
        [SerializeField] private TMP_Text producingResourceAmountText;
        
    
    
        public ManufactureType ManufactureType { get => ManufactureType; 
            set => manufactureTypeText.text = value.ToString(); }
        public ResourceType ProducingResourceType { get => ProducingResourceType; 
            set => producingResourceText.text = value.ToString(); }
        public int ProducingResource { get => ProducingResource; 
            set => producingResourceAmountText.text = value.ToString(); }
        public Vector3 Position { get => Position; 
            set => transform.position = value; }
    }
}