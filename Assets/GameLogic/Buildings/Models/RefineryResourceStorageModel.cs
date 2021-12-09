using System;
using CommonBaseUI.Data;

namespace GameLogic.Manufacture
{
    public class RefineryResourceStorageModel : IResourceStorageModel
    {
        private int resourceAmount;

        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly IRefineryProduceStorageModel refineryProduceStorageModel;
        private readonly ResourceStorageData resourceStorageData;

        public event Action OnProducingResource;
        public int ResourceAmount => resourceAmount < 1 ? 0 : resourceAmount;

        public RefineryResourceStorageModel(IBuildingUpgraderModel buildingUpgraderModel,
            IRefineryProduceStorageModel refineryProduceStorageModel)
        {
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.refineryProduceStorageModel = refineryProduceStorageModel;
            
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

            if (refineryProduceStorageModel.AddResource(resource)) ;
            {
                return true;
            }
        }

        public bool ProduceResource()
        {
            if (refineryProduceStorageModel.SpendResourceForCreateResource()) ;
            {
                resourceAmount++;
                OnProducingResource?.Invoke();
                return true;
            }
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