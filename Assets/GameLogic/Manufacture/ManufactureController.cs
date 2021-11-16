namespace GameLogic.Manufacture
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
            
            model.OnUpgrade += ModelOnUpgrade;
            
            view.OnClick += ViewOnClick;
            
            view.onCollision += ViewOnCollision;

            Init();
        }

        private void ModelOnProducingResource()
        {
            view.ProducingResource = model.ResourceAmount;
        }

        private void ModelOnUpgrade()
        {
            view.OnUpgrade();
        }

        private void ViewOnClick()
        {
            model.AddSenderModel();
        }

        private void ViewOnCollision()
        {
            model.AddReceiverModel();
        }


        private void Init()
        {
            view.Position = model.ManufactureData.Position;
            view.ManufactureType = model.ManufactureData.ManufactureType;
            view.ProducingResourceType = model.ManufactureData.ProducingResource;
        }
    }
}