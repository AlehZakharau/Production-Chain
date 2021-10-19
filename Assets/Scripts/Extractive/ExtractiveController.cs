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
            
            //model.OnInitial += ModelOnOnInitial;
            
            view.OnProducing += ViewOnOnProducing;
            
            SyncProducing();
            
            SyncInitial();
        }

        private void ViewOnOnProducing()
        {
            model.ResourceItem++;
        }

        private void ModelOnOnInitial()
        {
            SyncInitial();
        }

        private void ModelOnOnProducingItem()
        {
            SyncProducing();
        }

        private void SyncProducing()
        {
            view.ResourceItem = model.ResourceItem;
        }

        private void SyncInitial()
        {
            view.ProducingSpeed = model.ProducingSpeed;
            view.ResourceType = model.ResourceType;
            view.ExtractiveType = model.ExtractiveType;
            view.Position = model.Position;
            view.ExtractiveColor = model.ExtractiveColor;
        }
    }
}