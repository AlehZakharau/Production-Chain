using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace Refinery
{
    public interface IRefineryModel
    {
        event Action OnProducingItem;

        public ResourceType ResourceType { get; set; }
        public int ResourceItem { get; set; }

        public float ProducingSpeed { get; set; }

        public Vector3 Position { get; set; }

        public RefineryType RefineryType { get; set; }
        
        public Color RefineryColor { get; set; }

        public void Initialize(RefineryInitializeModel.InitializeData initializeData);

        public Dictionary<ResourceType, int> DemandResourceTypes { get; set; }
        public void AddDemandResource(ResourceType resourceType, int amount);
        
        public ResourceType[] DemandResources { get; set; }
    }
    
    public class RefineryModel: IRefineryModel
    {
        private int resourceItem;

        public event Action OnProducingItem;

        public ResourceType ResourceType { get; set; }
        public int ResourceItem
        {
            get => resourceItem;
            set
            {
                if (resourceItem == value) return;
                {
                    resourceItem = value;
                    OnProducingItem?.Invoke();
                }   
            }
        }

        public float ProducingSpeed { get; set; }
        public Vector3 Position { get; set; }
        public RefineryType RefineryType { get; set; }
        public Color RefineryColor { get; set; }

        public void Initialize(RefineryInitializeModel.InitializeData initializeData)
        {
            DemandResourceTypes = new Dictionary<ResourceType, int>();
            ProducingSpeed = initializeData.ProductionSpeed;
            RefineryType = initializeData.RefineryType;
            RefineryColor = GetColor(initializeData.RefineryType);
            Position = initializeData.SpawnPosition.position;
            DemandResources = initializeData.DemandResourceType;
            foreach (var resource in initializeData.DemandResourceType)
            {
                if (!DemandResourceTypes.ContainsKey(resource)) 
                    DemandResourceTypes.Add(resource, 0);
            }
        }
        public Dictionary<ResourceType, int> DemandResourceTypes { get; set; }

        public void AddDemandResource(ResourceType resourceType, int amount)
        {
            DemandResourceTypes[resourceType] += amount;
            
            ProduceItem(amount);
        }

        public ResourceType[] DemandResources { get; set; }


        private void ProduceItem(int amount)
        {
            if (DemandResourceTypes.Any(
                resource => resource.Value < amount))
            {
                return;
            }

            foreach (var resource in DemandResourceTypes.Keys)
            {
                DemandResourceTypes[resource] -= amount;
            }

            ResourceItem++;
        }

        private Color GetColor(RefineryType extractiveType)
        {
            switch (extractiveType)
            {
                case RefineryType.BlueCube:
                    return Color.blue;
                case RefineryType.RedSphere:
                    return Color.red;
                case RefineryType.YellowCone:
                    return Color.yellow;
                default:
                    return Color.white;
            }
        }

    }
}