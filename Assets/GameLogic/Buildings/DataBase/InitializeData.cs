using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Manufacture
{
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
            public List<ResourceType> demandUpgradeResource;
            public int[] demandUpgradeResourceCapacity;
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
            public float productionSpeed;
            // has to be equals levelInitData.Length or higher;
            public float[] productionSpeedUpgrade;
            public int[] resourceCapacity;
        }
    }
}