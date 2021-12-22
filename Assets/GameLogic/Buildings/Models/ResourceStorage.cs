using GameLogic.Buildings.Interfaces;
using GameLogic.Transport;

namespace GameLogic.Buildings.Models
{
    public class ResourceStorage : IResourceStorage
    {
        public IBuildingModel BuildingModel { get; }

        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly TransportationService transportationService;
        

        public ResourceStorage(IBuildingModel buildingModel, IBuildingUpgraderModel buildingUpgraderModel,
            TransportationService transportationService)
        {
            BuildingModel = buildingModel;
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.transportationService = transportationService;
        }

        /// <summary>
        /// Doesn't call this method in Manufactures, becoase it calls in ManufactureModel.
        /// Need to fix in the future.
        /// </summary>
        public void OnClick()
        {
            if(BuildingModel.BuildingsType == BuildingsType.Extractor) return;
            transportationService.CallTransportService(this);
        }

        public bool AddDemandResources(ResourceType resource)
        {
            if (buildingUpgraderModel.AddResource(resource))
            {
                return true;
            }
            return false;
        }

        public bool CheckResource(ResourceType resource)
        {
            return buildingUpgraderModel.CheckResource(resource);
        }
    }
}