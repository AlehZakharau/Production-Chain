using TMPro;
using UnityEngine;

namespace Extractive
{
    public interface IExtractiveView
    {
        int ResourceItem {  set; }
    }
    
    public class ExtractiveView : MonoBehaviour, IExtractiveView
    {
        [SerializeField] private TMP_Text text;
        
        
        public int ResourceItem { set => text.text = value.ToString(); }
    }
}