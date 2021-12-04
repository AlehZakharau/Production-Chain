using System;
using System.Collections.Generic;

namespace GameLogic.Manufacture
{
    public class ResourceStorageModel : IResourceStorageModel
    {
        public event Action OnUpgrade;

        private int resourceAmount;

        private readonly IBuildingUpgraderModel buildingUpgraderModel;

        public int ResourceAmount => resourceAmount < 1 ? 0 : resourceAmount;

        public ResourceStorageModel(IBuildingUpgraderModel buildingUpgraderModel)
        {
            this.buildingUpgraderModel = buildingUpgraderModel;
            buildingUpgraderModel.OnUpgrade += () => OnUpgrade?.Invoke();
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
            return true;
        }
    }
}