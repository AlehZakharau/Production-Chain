using System;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic.Manufacture
{
    internal class ManufactureModel : IBuildingModel, ITickable
    {
        public event Action OnProducingResource;

        private float timer;

        private readonly IResourceStorageModel resourceStorageModel;
        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        
        public BuildingsType BuildingsType { get; set; }
        public Vector3 Position { get; set; }

        private readonly float producingSpeed;
        public ManufactureModel(IResourceStorageModel resourceStorageModel,
            IBuildingUpgraderModel buildingUpgraderModel, InitializeData.InitData initData, 
            InitializeData.ManufactureInitData manufactureInitData)
        {
            this.resourceStorageModel = resourceStorageModel;
            this.buildingUpgraderModel = buildingUpgraderModel;
            
            BuildingsType = initData.buildingsType;
            
            producingSpeed = manufactureInitData.productionSpeed;
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