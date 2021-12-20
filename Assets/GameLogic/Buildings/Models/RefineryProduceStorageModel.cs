using System.Collections.Generic;
using System.Linq;
using CommonBaseUI.Data;

namespace GameLogic.Manufacture
{
    public interface IRefineryProduceStorageModel
    {
        public Dictionary<ResourceType, int> ProduceResources { get; }

        public bool AddResource(ResourceType resourceType);

        public bool SpendResourceForCreateResource();

        public bool CheckResource(ResourceType resource);
    }
    public class RefineryProduceStorageModel : IRefineryProduceStorageModel
    {
        private readonly List<ResourceType> demandProductionResources;
        private readonly Dictionary<ResourceType, int> productionResources;
        private readonly RefineryData refineryData;

        public Dictionary<ResourceType, int> ProduceResources => productionResources;

        public RefineryProduceStorageModel(InitializeData.RefineryInitData initData)
        {
            demandProductionResources = initData.demandProducingResources;
            
            productionResources = new Dictionary<ResourceType, int>();
            foreach (var resource in demandProductionResources)
            {
                productionResources.Add(resource, 0);
            }

            refineryData = new RefineryData();
            DataManager.Instance.buildingsData.RefineryData.Add(refineryData);
            DataManager.Instance.GetDataOnSave += SaveData;
            DataManager.Instance.SendDataOnLoad += LoadData;
        }

        public bool AddResource(ResourceType resourceType)
        {
            if (demandProductionResources.Contains(resourceType))
            {
                productionResources[resourceType]++;
                return true;
            }
            return false;
        }

        public bool SpendResourceForCreateResource()
        {
            if (productionResources.Any(
                resource => resource.Value < 1))
            {
                return false;
            }
            foreach (var varResource in demandProductionResources)
            {
                productionResources[varResource]--;
            }
            return true;
        }

        public bool CheckResource(ResourceType resource)
        {
            return demandProductionResources.Contains(resource);
        }

        private void SaveData()
        {
            refineryData.demandResources = productionResources.Values.ToArray();
        }

        private void LoadData()
        {
            var index = 0;
            foreach (var resource in productionResources.Keys)
            {
                productionResources[resource] = refineryData.demandResources[index++];
            }
        }
    }
}