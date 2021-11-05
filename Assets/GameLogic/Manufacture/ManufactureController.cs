namespace GameLogic.ProductionPoint
{
    public interface IManufactureController
    {
        
    }
    public class ManufactureController : IManufactureController
    {
        private readonly IManufactureModel model;
        private readonly IManufactureView view;

        public ManufactureController(IManufactureModel model,
            IManufactureView view)
        {
            this.model = model;
            this.view = view;
            
            model.OnProducingResource += ModelOnProducingResource;
            
            Init();
        }

        private void ModelOnProducingResource()
        {
            view.ProducingResource = model.ResourceAmount;
        }


        private void Init()
        {
            view.Position = model.ManufactureData.Position;
            view.ManufactureType = model.ManufactureData.ManufactureType;
            view.ProducingResourceType = model.ManufactureData.ProducingResource;
        }
    }
}