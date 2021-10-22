using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.ProductionPoint
{
    public interface IProductionPointView
    {
        public event Action onClick;
        public ProductionPointType ProductionPointType { get; set; }
        public ResourceType ProducingResourceType { get; set; }
        public int ProducingResource { get; set; }
        public ResourceType[] DemandResourceTypes { get; set; }
        public Vector3 Position { get; set; }
    }
    public class ProductionPointView : MonoBehaviour, IProductionPointView
    {
        [SerializeField] private TMP_Text resourceTypeText;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private TMP_Text productionPointTypeText;
        [SerializeField] private TMP_Text demandResources;
        
        public event Action onClick;

        public ProductionPointType ProductionPointType { get => ProductionPointType; 
            set => productionPointTypeText.text = value.ToString(); }
        public ResourceType ProducingResourceType { get => ProducingResourceType;
            set => resourceTypeText.text = value.ToString(); }
        public int ProducingResource { get => ProducingResource; 
            set => amountText.text = value.ToString(); }
        public ResourceType[] DemandResourceTypes { get => DemandResourceTypes;
            set => demandResources.text = value.ToString(); }
        public Vector3 Position { get => Position;
            set => transform.position = value; }

        private void OnMouseDown()
        {
            onClick?.Invoke();
        }
    }
}