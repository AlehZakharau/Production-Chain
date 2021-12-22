namespace GameLogic.Buildings.Interfaces
{
    public interface IResourceStorage
    {
        public bool AddDemandResources(ResourceType resource);
        public bool CheckResource(ResourceType resource);
        public IBuildingModel BuildingModel { get; }
        public void OnClick();
    }
}