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
            DataManager.Instance.GetDataOnSave += SaveData;
            DataManager.Instance.SendDataOnLoad += LoadData;
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
            OnProducingResource?.Invoke();
            return true;
        }

        private void SaveData()
        {
            resourceStorageData.resourceAmount = resourceAmount;
        }

        private void LoadData()
        {
            resourceAmount = resourceStorageData.resourceAmount;
        }
    }
}