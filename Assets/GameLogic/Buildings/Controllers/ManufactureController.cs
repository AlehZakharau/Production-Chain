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
        private readonly IResourceStorage resourceStorage;

        public ManufactureController(IManufactureModel manufactureModel,
            IManufactureView manufactureView, IBuildingClicable buildingClicable,
            IResourceStorage resourceStorage)
        {
            this.manufactureModel = manufactureModel;
            this.manufactureView = manufactureView;
            this.buildingClicable = buildingClicable;
            this.resourceStorage = resourceStorage;
            
            buildingClicable.OnClick += OnClick;
            
            Init();
        }

        private void Init()
        {
            manufactureView.ResourceType = manufactureModel.ResourceType;
        }

        private void OnClick()
        {
            if (manufactureModel.BuildingModel.BuildingsType ==
                BuildingsType.Extractor ||
                manufactureModel.BuildingModel.BuildingsType ==
                BuildingsType.Refinery)
            {
                manufactureModel.OnClick();
            }
            else
            {
                resourceStorage.OnClick();
            }
        }
    }
}