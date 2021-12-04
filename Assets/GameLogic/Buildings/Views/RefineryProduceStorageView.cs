using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Manufacture
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