using System;
using System.Collections.Generic;
using CommonBaseUI.Data;
using GameLogic.Transport;

namespace GameLogic.Manufacture
{
    public class ResourceStorageModel : IResourceStorageModel
    {
        private int resourceAmount;
        private int resourceCapacity = 20;

        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly ResourceStorageData resourceStorageData;
        private readonly TransportationService transportationService;
        public event Action OnProducingResource;
        public IBuildingModel BuildingModel { get; }

        public int ResourceAmount
        {
            get => resourceAmount < 1 ? 0 : resourceAmount;
            set
            {
                if(resourceAmount >= resourceCapacity) return;
                resourceAmount = value;
            }
        }

        public ResourceStorageModel(IBuildingModel buildingModel, IBuildingUpgraderModel buildingUpgraderModel,
            TransportationService transportationService)
        {
            BuildingModel = buildingModel;
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.transportationService = transportationService;

            resourceStorageData = new ResourceStorageData();
            DataManager.Instance.buildingsData.ResourceStorageData.Add(resourceStorageData);
            DataManager.Instance.GetDataOnSave += SaveData;
            DataManager.Instance.SendDataOnLoad += LoadData;
        }

        public void OnClick()
        {
            if(BuildingModel.BuildingsType == BuildingsType.Extractor ||
                BuildingModel.BuildingsType == BuildingsType.Refinery) return;
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

        public bool ProduceResource()
        {
            ResourceAmount++;
            OnProducingResource?.Invoke();
            return true;
        }

        public bool CheckResource(ResourceType resource)
        {
            return buildingUpgraderModel.CheckResource(resource);
        }

        private void SaveData()
        {
            resourceStorageData.resourceAmount = ResourceAmount;
        }

        private void LoadData()
        {
            ResourceAmount = resourceStorageData.resourceAmount;
        }
    }
}