using System;
using System.Collections.Generic;
using CommonBaseUI.Data;

namespace GameLogic.Manufacture
{
    public class ResourceStorageModel : IResourceStorageModel
    {
        private int resourceAmount;

        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly ResourceStorageData resourceStorageData;
        public event Action OnProducingResource;
        public int ResourceAmount => resourceAmount < 1 ? 0 : resourceAmount;

        public ResourceStorageModel(IBuildingUpgraderModel buildingUpgraderModel)
        {
            this.buildingUpgraderModel = buildingUpgraderModel;

            resourceStorageData = new ResourceStorageData();
            DataManager.Instance.buildingsData.ResourceStorageData.Add(resourceStorageData);
        }

        public bool AddDemandResources(ResourceType resource)
        {
            if (buildingUpgraderModel.AddResource(resource))
            {
                return true;
            }
            return false;
        }
        public bool ProduceResource()
        {
            resourceAmount++;
            resourceStorageData.resourceAmount = resourceAmount;
            OnProducingResource?.Invoke();
            return true;
        }
    }
}