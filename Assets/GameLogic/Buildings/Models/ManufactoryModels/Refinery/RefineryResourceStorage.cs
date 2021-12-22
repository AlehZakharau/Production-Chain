using System;
using CommonBaseUI.Data;
using GameLogic.Transport;

namespace GameLogic.Manufacture
{
    public class RefineryResourceStorage : IResourceStorage
    {
        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly IRefineryProduceStorageModel refineryProduceStorageModel;

        public IBuildingModel BuildingModel { get; }


        public RefineryResourceStorage(IBuildingModel buildingModel, 
            IBuildingUpgraderModel buildingUpgraderModel,
            IRefineryProduceStorageModel refineryProduceStorageModel)
        {
            BuildingModel = buildingModel;
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.refineryProduceStorageModel = refineryProduceStorageModel;
            
        }
        
        public void OnClick()
        {
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

        public bool CheckResource(ResourceType resource)
        {
            return buildingUpgraderModel.CheckResource(resource) &&
                   refineryProduceStorageModel.CheckResource(resource);
        }
    }
}