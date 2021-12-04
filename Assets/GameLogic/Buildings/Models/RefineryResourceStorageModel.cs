using System;

namespace GameLogic.Manufacture
{
    public class RefineryResourceStorageModel : IResourceStorageModel
    {
        public event Action OnUpgrade;

        private int resourceAmount;

        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly IRefineryProduceStorageModel refineryProduceStorageModel;

        public int ResourceAmount => resourceAmount < 1 ? 0 : resourceAmount;

        public RefineryResourceStorageModel(IBuildingUpgraderModel buildingUpgraderModel,
            IRefineryProduceStorageModel refineryProduceStorageModel)
        {
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.refineryProduceStorageModel = refineryProduceStorageModel;
            buildingUpgraderModel.OnUpgrade += () => OnUpgrade?.Invoke();
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
                return true;
            }
        }
    }
}