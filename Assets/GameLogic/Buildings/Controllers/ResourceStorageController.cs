namespace GameLogic.Manufacture
{
    public interface IResourceStorageController
    {
        
    }
    public class ResourceStorageController : IResourceStorageController
    {
        private readonly IResourceStorageModel resourceStorageModel;
        private readonly IResourceStorageView resourceStorageView;

        public ResourceStorageController(IResourceStorageModel resourceStorageModel,
            IResourceStorageView resourceStorageView)
        {
            this.resourceStorageModel = resourceStorageModel;
            this.resourceStorageView = resourceStorageView;
            
            
            resourceStorageModel.OnProducingResource += OnProducingResource;
        }

        private void OnProducingResource()
        {
            resourceStorageView.ResourceAmount = resourceStorageModel.ResourceAmount;
        }
    }
}