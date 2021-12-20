using System;
using CommonBaseUI.Data;
using GameLogic.Transport;

namespace GameLogic.Manufacture
{
    public class RefineryResourceStorageModel : IResourceStorageModel
    {
        private int resourceAmount;

        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        private readonly IRefineryProduceStorageModel refineryProduceStorageModel;
        private readonly ResourceStorageData resourceStorageData;
        private readonly TransportationService transportationService;

        public event Action OnProducingResource;
        public IBuildingModel BuildingModel { get; }

        public int ResourceAmount
        {
            get { return resourceAmount < 1 ? 0 : resourceAmount; }
            set{}
        }

        public bool IsReceiver { get; set; }


        public RefineryResourceStorageModel(IBuildingModel buildingModel, 
            IBuildingUpgraderModel buildingUpgraderModel,
            IRefineryProduceStorageModel refineryProduceStorageModel,
            TransportationService transportationService)
        {
            BuildingModel = buildingModel;
            this.buildingUpgraderModel = buildingUpgraderModel;
            this.refineryProduceStorageModel = refineryProduceStorageModel;
            this.transportationService = transportationService;
            
            resourceStorageData = new ResourceStorageData();
            DataManager.Instance.buildingsData.ResourceStorageData.Add(resourceStorageData);
            DataManager.Instance.GetDataOnSave += SaveData;
            DataManager.Instance.SendDataOnLoad += LoadData;
        }
        
        public void OnClick()
        {
            transportationService.CallTransportService(this);
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
                OnProducingResource?.Invoke();
                return true;
            }
        }

        public bool CheckResource(ResourceType resource)
        {
            return buildingUpgraderModel.CheckResource(resource) &&
                   refineryProduceStorageModel.CheckResource(resource);
        }

        private void SaveData()
        {
            resourceStorageData.resourceAmount = resourceAmount;
        }

        private void LoadData()
        {
            resourceAmount = resourceStorageData.resourceAmount;
        }
    }
}