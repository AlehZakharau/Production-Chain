using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic.Manufacture
{
    public interface IBuildingUpgraderModel
    {
        public event Action OnUpgrade;
        
        public int Level { get; set; }
        public Dictionary<ResourceType, int> UpgradeResources { get; }

        public bool AddResource(ResourceType resource);
    }
    public class BuildingUpgraderModel : IBuildingUpgraderModel
    {
        public event Action OnUpgrade;

        public int Level
        {
            get => level;
            set
            {
                OnUpgrade?.Invoke();
                level = value;
            }
        }

        public Dictionary<ResourceType, int> 
            UpgradeResources => upgradeResources;

        private int level;
        private float upgradeProductionSpeedCoefficient;

        private InitializeData.LevelInitData currentLevelInit;
        private readonly InitializeData.LevelInitData[] levelsData;
        private List<ResourceType> demandUpgradeResources;
        private Dictionary<ResourceType, int> upgradeResources;

        public BuildingUpgraderModel(InitializeData.LevelInitData[] levelsData)
        {
            this.levelsData = levelsData;
            upgradeProductionSpeedCoefficient = levelsData[level].upgradeProductionSpeedCoefficient;
        }

        public bool AddResource(ResourceType resource)
        {
            upgradeResources[resource]--;
            CheckUpgradeOpportunity();
            return false;
        }
        
        private void CheckUpgradeOpportunity()
        {
            if(upgradeResources.All(resource => resource.Value < 1))
            {
                OnUpgrade?.Invoke();
                level++;
                UpgradeDataToNewLevel(level);
            }
        }
        
        private void UpgradeDataToNewLevel(int level)
        {
            if(level >= levelsData.Length - 1) return;
            currentLevelInit = levelsData[level];
            //ProductionSpeed = currentLevel.productionSpeed;
            demandUpgradeResources = currentLevelInit.demandUpgradeResource;
            upgradeResources = new Dictionary<ResourceType, int>();
            for (var i = 0; i < demandUpgradeResources.Count; i++)
            {
                upgradeResources.Add(demandUpgradeResources[i], currentLevelInit.demandUpgradeResourceCapacity[i]);
            }
        }
        
        private void SetUpgradeResourceAmount(int[] values)
        {
            // if (values.Length != productionResources.Count)
            //     throw new Exception();
            var index = 0;
            foreach (var resource in upgradeResources.Keys.ToList())
            {
                upgradeResources[resource] = values[index++];
            }
        }
    }
}