using System;

namespace GameLogic.Manufacture
{
    public interface IResourceStorageModel
    {
        public event Action OnProducingResource;
        public int ResourceAmount { get; }

        public bool AddDemandResources(ResourceType resource);

        public bool ProduceResource();
    }
}