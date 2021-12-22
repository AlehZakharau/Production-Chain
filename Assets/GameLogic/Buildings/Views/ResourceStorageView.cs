using TMPro;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IProduceView
    {
        public int ResourceAmount { get; set; }
    }
    public class ProduceView : MonoBehaviour, IProduceView
    {
        [SerializeField] private TMP_Text resourceAmountText;
        public int ResourceAmount { get => ResourceAmount; set =>
            resourceAmountText.text = value.ToString(); }
    }
}