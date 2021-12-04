using System.Collections.Generic;
using System.Linq;

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

        public Dictionary<ResourceType, int> ProduceResources => productionResources;

        public RefineryProduceStorageModel(InitializeData.RefineryInitData initData)
        {
            demandProductionResources = initData.demandProducingResources;
            
            productionResources = new Dictionary<ResourceType, int>();
            foreach (var resource in demandProductionResources)
            {
                productionResources.Add(resource, 0);
            }
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
    }
}