namespace Extractive
{
    public interface IExtractiveController
    {
        
    }
    
    public class ExtractiveController : IExtractiveController
    {
        private readonly IExtractiveModel model;
        private readonly IExtractiveView view;

        public ExtractiveController(IExtractiveModel model, IExtractiveView view)
        {
            this.model = model;
            this.view = view;
            
            model.OnProducingItem += ModelOnOnProducingItem;
            
            SyncProducing();
        }

        private void ModelOnOnProducingItem()
        {
            SyncProducing();
        }

        private void SyncProducing()
        {
            view.ResourceItem = model.ResourceItem;
        }
    }
}