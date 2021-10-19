using System.Security;

namespace Refinery
{
    public interface IRefineryController
    {
        
    }
    
    public class RefineryController : IRefineryController
    {
        private readonly IRefineryModel model;
        private readonly IRefineryView view;

        public RefineryController(IRefineryModel model, IRefineryView view)
        {
            this.model = model;
            this.view = view;
            
            
            model.OnProducingItem += ModelOnOnProducingItem;
            
            view.OnProducing += ViewOnOnProducing;
            
            SyncProducing();
            
            SyncInitial();
        }

        private void ViewOnOnProducing()
        {
            model.ResourceItem++;
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
            view.Position = model.Position;
            //view.DemandResources
            view.RefineryType = model.RefineryType;
            view.ProducingSpeed = model.ProducingSpeed;
            view.ResourceType = model.ResourceType;
            view.RefineryColor = model.RefineryColor;
            view.DemandResources = model.DemandResources;
            view.ChangeDemandText();
        }
    }
    
}