using System.Collections.Generic;

namespace GameLogic.Manufacture
{
    public interface IBuildingUpgraderView
    {
        public int Level { get; set; }
        public Dictionary<ResourceType, int> UpgradeResources { get; set; }
    }
    
    
    public class BuildingUpgraderView : IBuildingUpgraderView
    {
        public int Level { get; set; }
        public Dictionary<ResourceType, int> UpgradeResources { get; set; }
    }
}