using System;
using TMPro;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IManufactureView
    {
        public event Action OnClick;

        public event Action onCollision;
        public ManufactureType ManufactureType { get; set; }
        public ResourceType ProducingResourceType { get; set; }
        public int ProducingResource { get; set; }
        public Vector3 Position { get; set; }
    }

    public class ManufactureView : MonoBehaviour, IManufactureView, IClickable, ICollisionally
    {
        [SerializeField] private TMP_Text manufactureTypeText;
        [SerializeField] private TMP_Text producingResourceText;
        [SerializeField] private TMP_Text producingResourceAmountText;

        public event Action OnClick;
        public event Action onCollision;

        public ManufactureType ManufactureType { get => ManufactureType; 
            set => manufactureTypeText.text = value.ToString(); }
        public ResourceType ProducingResourceType { get => ProducingResourceType; 
            set => producingResourceText.text = value.ToString(); }
        public int ProducingResource { get => ProducingResource; 
            set => producingResourceAmountText.text = value.ToString(); }
        public Vector3 Position { get => Position; 
            set => transform.position = value; }
        
        private bool isSelected;
        private Material baseMaterial;

        private Color baseColor;
        
        private void Awake()
        {
            baseMaterial = GetComponentInChildren<MeshRenderer>().material;
            baseColor = baseMaterial.color;
        }

        public void Click()
        {
            OnClick?.Invoke();
        }

        public void Select()
        {
            baseMaterial.color = Color.yellow;
        }

        public void UnSelect()
        {
            baseMaterial.color = baseColor;
        }

        public void Execute()
        {
           onCollision?.Invoke();
        }
    }
}