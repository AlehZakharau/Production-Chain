using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public class BuildingInitData : MonoBehaviour
    {
        public BuildingsType buildingsType;
        [SerializeField] private InitializeData.InitData initData;

        [SerializeField] private InitializeData.ManufactureInitData manufactureInitData;
        [SerializeField] private InitializeData.RefineryInitData refineryInitData;
        [SerializeField] private InitializeData.LevelInitData[] levelsInitData =
            new[] { new InitializeData.LevelInitData(), new InitializeData.LevelInitData()};

        public InitializeData.InitData InitData => initData;
        public InitializeData.ManufactureInitData ManufactureInitData => manufactureInitData;
        public InitializeData.RefineryInitData RefineryInitData => refineryInitData;
        public InitializeData.LevelInitData[] LevelInitData => levelsInitData;
        //public ManufactureData ManufactureData => new ManufactureData(initData, levelsInitData);

#if UNITY_EDITOR
        
        private void InitializeForEditor () {
            if (initData.buildingsType == BuildingsType.Refinery)
            {
                this.gameObject.AddComponent<WorldCreator>();
            }
        }
        private void Awake()
        {
            
            CheckInitData();
        }
        private void CheckInitData()
        {
            if (refineryInitData.demandProducingResources.Count < 1)
            {
                Debug.LogWarning($"<color=blue>Init Data</color>" +
                                 $"Demand Producing resources for {this} is empty");
            }

            foreach (var levelData in levelsInitData)
            {
                if (levelData.demandUpgradeResource.Count < 1)
                {
                    Debug.LogWarning($"<color=blue>Init Data</color>" +
                                     $"Demand Upgrade resources for {this} is empty");
                }

                if (levelData.demandUpgradeResource.Count !=
                    levelData.demandUpgradeResourceCapacity.Length)
                {
                    Debug.LogWarning($"<color=blue>Init Data</color>" +
                                     $"Demand Upgrade resources or Capacity has mistake {this}");
                }

                foreach (var capacity in levelData.demandUpgradeResourceCapacity)
                {
                    if (capacity == 0)
                        Debug.LogWarning($"<color=blue>Init Data</color>" +
                                         $"Demand Upgrade resources capacity is 0 {this}");
                }
            }
        }
#endif
    }
    
    [Serializable]
    public class InitializeData
    {
        [Serializable]
        public struct InitData
        {
            public BuildingsType buildingsType;
            public Transform Position;
            public int startLevel;
        }
        [Serializable]
        public struct LevelInitData
        {
            public  List<ResourceType> demandUpgradeResource;
            public  int[] demandUpgradeResourceCapacity;
            public  float upgradeProductionSpeedCoefficient;
        }
        [Serializable]
        public struct RefineryInitData
        {
            public List<ResourceType> demandProducingResources;
        }
        [Serializable]
        public struct ManufactureInitData
        {
            public ResourceType resourceType;
            public  float productionSpeed;
            public  Color color;
        }
    }
}