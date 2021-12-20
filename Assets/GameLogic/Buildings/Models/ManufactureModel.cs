using System;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IManufactureModel
    {
        public ResourceType ResourceType { get; set; }
        public bool IsSender { get; set; }
        public IBuildingModel BuildingModel { get; }
        public int GetResourceAmount();
        public void TransportingResource();
        public void OnClick();
    }
    internal class ManufactureModel : IManufactureModel, ITickable
    {
        private float timer;

        private readonly IResourceStorageModel resourceStorageModel;
        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly TransportationService transportationService;

        public ResourceType ResourceType { get; set; }
        public bool IsSender { get; set; }
        public IBuildingModel BuildingModel { get; }

        private readonly float producingSpeed;

        public ManufactureModel(IBuildingModel buildingModel, IResourceStorageModel resourceStorageModel,
            IBuildingUpgraderModel buildingUpgraderModel, 
            InitializeData.ManufactureInitData manufactureInitData,
            TransportationService transportationService)
        {
            BuildingModel = buildingModel;
            this.resourceStorageModel = resourceStorageModel;
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.transportationService = transportationService;

            producingSpeed = manufactureInitData.productionSpeed;
            ResourceType = manufactureInitData.resourceType;
        }

        public void Tick()
        {
            timer += Time.deltaTime;
            if (timer > producingSpeed && buildingUpgraderModel.Level > 0)
            {
                timer = 0;
                resourceStorageModel.ProduceResource();
            }
        }

        public int GetResourceAmount()
        {
            return resourceStorageModel.ResourceAmount;
        }

        public void TransportingResource()
        {
            resourceStorageModel.ResourceAmount--;
        }

        public void OnClick()
        {
            if (!IsSender)
            {
                transportationService.CallTransportService(this, resourceStorageModel);
            }
        }

        // public void AddManufactureModel()

        // {

        //     var status = transportationService.AddManufactureModel(this);

        //     if (status)

        //     {

        //         OnConnectionSuccess?.Invoke();

        //     }

        //     else

        //     {

        //         OnConnectionFail?.Invoke();

        //     }

        // }
    }
}