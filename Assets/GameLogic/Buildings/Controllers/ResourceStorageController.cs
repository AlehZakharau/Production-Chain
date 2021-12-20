namespace GameLogic.Manufacture
{
    public interface IResourceStorageController
    {
        
    }
    public class ResourceStorageController : IResourceStorageController
    {
        private readonly IResourceStorageModel resourceStorageModel;
        private readonly IResourceStorageView resourceStorageView;
        private readonly IBuildingClicable buildingClicable;

        public ResourceStorageController(IResourceStorageModel resourceStorageModel,
            IResourceStorageView resourceStorageView, IBuildingClicable buildingClicable)
        {
            this.resourceStorageModel = resourceStorageModel;
            this.resourceStorageView = resourceStorageView;
            this.buildingClicable = buildingClicable;
            
            
            resourceStorageModel.OnProducingResource += OnProducingResource;
            
            buildingClicable.OnClick += OnClick;
        }

        private void OnClick()
        {
            resourceStorageModel.OnClick();
        }

        private void OnProducingResource()
        {
            resourceStorageView.ResourceAmount = resourceStorageModel.ResourceAmount;
        }
    }
}