using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Buildings.Views
{
    public interface IRefineryProduceStorageView
    {
        public Dictionary<ResourceType, int> ProduceResources { get; set; }
    }
    
    public class RefineryProduceStorageView : MonoBehaviour, IRefineryProduceStorageView
    {
        public Dictionary<ResourceType, int> ProduceResources { get; set; }
    }
}