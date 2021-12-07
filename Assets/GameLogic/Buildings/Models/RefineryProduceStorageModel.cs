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
        }

        public bool AddResource(ResourceType resourceType)
        {
            if (demandProductionResources.Contains(resourceType))
            {
                productionResources[resourceType]++;
                refineryData.demandResources = productionResources.Values.ToArray();
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
                refineryData.demandResources = productionResources.Values.ToArray();
            }
            return true;
        }
    }
}