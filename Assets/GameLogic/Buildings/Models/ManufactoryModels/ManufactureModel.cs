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
        public ResourceType ResourceType { get; set; }
        public bool IsSender { get; set; }
        public IBuildingModel BuildingModel { get; }

        private readonly IResourceStorage resourceStorage;
        private readonly IProduceModel produceModel;
        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly TransportationService transportationService;
        private readonly InitializeData.ManufactureInitData manufactureInitData;
        
        private float producingSpeed;
        private float timer;

        public ManufactureModel(IBuildingModel buildingModel,
            IResourceStorage resourceStorage,
            IProduceModel produceModel,
            IBuildingUpgraderModel buildingUpgraderModel, 
            InitializeData.ManufactureInitData manufactureInitData,
            TransportationService transportationService)
        {
            BuildingModel = buildingModel;
            this.produceModel = produceModel;
            this.resourceStorage = resourceStorage;
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.transportationService = transportationService;
            this.manufactureInitData = manufactureInitData;

            producingSpeed = manufactureInitData.productionSpeed /
                             manufactureInitData.productionSpeedUpgrade[this.buildingUpgraderModel.Level];
            produceModel.ResourceCapacity = manufactureInitData.resourceCapacity[buildingUpgraderModel.Level];
            ResourceType = manufactureInitData.resourceType;

            this.buildingUpgraderModel.OnUpgrade += OnUpgrade;
        }

        public void Tick()
        {
            timer += Time.deltaTime;
            if (timer > producingSpeed && buildingUpgraderModel.Level > 0)
            {
                timer = 0;
                produceModel.ProduceResource();
            }
        }

        public int GetResourceAmount()
        {
            return produceModel.ResourceAmount;
        }

        public void TransportingResource()
        {
            produceModel.ResourceAmount--;
        }

        public void OnClick()
        {
            if (!IsSender)
            {
                transportationService.CallTransportService(this, resourceStorage);
            }
        }

        private void OnUpgrade()
        {
            producingSpeed = manufactureInitData.productionSpeed /
                             manufactureInitData.productionSpeedUpgrade[buildingUpgraderModel.Level];
            produceModel.ResourceCapacity = manufactureInitData.resourceCapacity[buildingUpgraderModel.Level];
        }
    }
}