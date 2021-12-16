using System;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IManufactureModel
    {
        public ResourceType ResourceType { get; set; }
    }
    internal class ManufactureModel : IManufactureModel, ITickable
    {
        private float timer;

        private readonly IResourceStorageModel resourceStorageModel;
        private readonly IBuildingUpgraderModel buildingUpgraderModel;

        public ResourceType ResourceType { get; set; }

        private readonly float producingSpeed;

        public ManufactureModel(IResourceStorageModel resourceStorageModel,
            IBuildingUpgraderModel buildingUpgraderModel, 
            InitializeData.ManufactureInitData manufactureInitData)
        {
            this.resourceStorageModel = resourceStorageModel;
            this.buildingUpgraderModel = buildingUpgraderModel;
            
            producingSpeed = manufactureInitData.productionSpeed;
            ResourceType = manufactureInitData.resourceType;
        }

        public void Tick()
        {
            timer += Time.deltaTime;
            if (timer > producingSpeed)
            {
                timer = 0;
                resourceStorageModel.ProduceResource();
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