namespace GameLogic.Manufacture
{
    public interface IManufactureController
    {
        
    }
    public class ManufactureController : IManufactureController
    {
        private readonly IManufactureModel manufactureModel;
        private readonly IManufactureView manufactureView;

        public ManufactureController(IManufactureModel manufactureModel,
            IManufactureView manufactureView)
        {
            this.manufactureModel = manufactureModel;
            this.manufactureView = manufactureView;
        }
    }
}