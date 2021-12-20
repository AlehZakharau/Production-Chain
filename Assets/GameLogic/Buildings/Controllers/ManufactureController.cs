namespace GameLogic.Manufacture
{
    public interface IManufactureController
    {
        
    }
    public class ManufactureController : IManufactureController
    {
        private readonly IManufactureModel manufactureModel;
        private readonly IManufactureView manufactureView;
        private readonly IBuildingClicable buildingClicable;

        public ManufactureController(IManufactureModel manufactureModel,
            IManufactureView manufactureView, IBuildingClicable buildingClicable)
        {
            this.manufactureModel = manufactureModel;
            this.manufactureView = manufactureView;
            this.buildingClicable = buildingClicable;
            
            buildingClicable.OnClick += OnClick;
            
            Init();
        }

        private void Init()
        {
            manufactureView.ResourceType = manufactureModel.ResourceType;
        }

        private void OnClick()
        {
            manufactureModel.OnClick();
        }
    }
}