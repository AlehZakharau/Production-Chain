using System;
using UnityEngine;

namespace DefaultNamespace.ProductionPoint
{
    [Serializable]
    public class ProductionPointInitializeModel
    {
        [Serializable]
        public struct InitializeData
        {
            public ResourceType resourceType;

            public ResourceType[] demandResources;

            public ProductionPointType productionPointType;

            public float productionSpeed;

            public Transform spawnPosition;
        }
    }
}