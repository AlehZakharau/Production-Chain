using TMPro;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IResourceStorageView
    {
        public int ResourceAmount { get; set; }
    }
    public class ResourceStorageView : MonoBehaviour, IResourceStorageView
    {
        [SerializeField] private TMP_Text resourceAmountText;
        public int ResourceAmount { get => ResourceAmount; set =>
            resourceAmountText.text = value.ToString(); }
    }
}