namespace GameLogic.Manufacture
{
    public interface IResourceStorageModel
    {
        public int ResourceAmount { get; }

        public bool AddDemandResources(ResourceType resource);

        public bool ProduceResource();
    }
}