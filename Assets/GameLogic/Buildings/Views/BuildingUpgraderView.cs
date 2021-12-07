using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IBuildingUpgraderView
    {
        public int Level { get; set; }
        public Dictionary<ResourceType, int> UpgradeResources { get; set; }
    }
    
    
    public class BuildingUpgraderView : MonoBehaviour, IBuildingUpgraderView
    {
        public int Level { get; set; }
        public Dictionary<ResourceType, int> UpgradeResources { get; set; }
    }
}