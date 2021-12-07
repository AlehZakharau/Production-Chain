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
                resourceStorageData.resourceAmount = resourceAmount;
                OnProducingResource?.Invoke();
                return true;
            }
        }
    }
}