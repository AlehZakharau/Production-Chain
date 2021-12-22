using System;
using System.Collections.Generic;
using System.Linq;
using CommonBaseUI.Data;
using GameLogic.Buildings.DataBase;

namespace GameLogic.Buildings.Models
{
    public interface IBuildingUpgraderModel
    {
        public event Action OnUpgrade;
        public int Level { get; set; }
        public Dictionary<ResourceType, int> UpgradeResources { get; }
        public bool AddResource(ResourceType resource);
        public bool CheckResource(ResourceType resource);
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

        public Dictionary<ResourceType, int> UpgradeResources => upgradeResources;

        private int level;
        private float upgradeProductionSpeedCoefficient;

        private InitializeData.LevelInitData currentLevelInit;
        private readonly InitializeData.LevelInitData[] levelsData;
        private List<ResourceType> demandUpgradeResources;
        private Dictionary<ResourceType, int> upgradeResources;
        private readonly UpgradeData upgradeData;

        public BuildingUpgraderModel(InitializeData.LevelInitData[] levelsData, InitializeData.InitData initData)
        {
            level = initData.startLevel;
            this.levelsData = levelsData;
            //upgradeProductionSpeedCoefficient = levelsData[level].upgradeProductionSpeedCoefficient;
            
            UpgradeDataToNewLevel(level);

            upgradeData = new UpgradeData();
            DataManager.Instance.buildingsData.UpgradeData.Add(upgradeData);
            DataManager.Instance.GetDataOnSave += SaveData;
            DataManager.Instance.SendDataOnLoad += LoadData;
        }

        public bool AddResource(ResourceType resource)
        {
            if (upgradeResources[resource] > 0)
            {
                upgradeResources[resource]--;
                CheckUpgradeOpportunity();
                return true;
            }
            return false;
        }

        public bool CheckResource(ResourceType resource)
        {
            return upgradeResources.ContainsKey(resource);
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
            if(level >= levelsData.Length) return;
            currentLevelInit = levelsData[level];
            //ProductionSpeed = currentLevel.productionSpeed;
            demandUpgradeResources = currentLevelInit.demandUpgradeResource;
            upgradeResources = new Dictionary<ResourceType, int>();
            for (var i = 0; i < demandUpgradeResources.Count; i++)
            {
                upgradeResources.Add(demandUpgradeResources[i], currentLevelInit.demandUpgradeResourceCapacity[i]);
            }
        }

        private void SaveData()
        {
            upgradeData.level = level;
            upgradeData.upgradeResources = upgradeResources.Values.ToArray();
        }

        private void LoadData()
        {
            Level = upgradeData.level;
            var index = 0;
            foreach (var resource in upgradeResources.Keys)
            {
                upgradeResources[resource] = upgradeData.upgradeResources[index++];
            }
        }
    }
}