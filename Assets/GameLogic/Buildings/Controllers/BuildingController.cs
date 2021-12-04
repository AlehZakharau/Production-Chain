namespace GameLogic.Manufacture
{
    public interface IBuildingController
    {
        
    }
    
    public class BuildingController : IBuildingController
    {
        private readonly IBuildingUpgraderModel upgraderModel;
        private readonly IBuildingUpgraderView upgraderView;
        private readonly IBuildingModel buildingModel;
        private readonly IBuildingView buildingView;

        public BuildingController(IBuildingUpgraderModel upgraderModel,
            IBuildingUpgraderView upgraderView, IBuildingModel buildingModel,
            IBuildingView buildingView)
        {
            this.upgraderModel = upgraderModel;
            this.upgraderView = upgraderView;
            this.buildingModel = buildingModel;
            this.buildingView = buildingView;
            
            upgraderModel.OnUpgrade += UpgraderModelOnOnUpgrade;
            
            Init();
        }

        private void UpgraderModelOnOnUpgrade()
        {
            upgraderView.Level = upgraderModel.Level;
            upgraderView.UpgradeResources = upgraderModel.UpgradeResources;
        }

        private void Init()
        {
            upgraderView.Level = upgraderModel.Level;
            upgraderView.UpgradeResources = upgraderModel.UpgradeResources;
            buildingView.BuildingsType = buildingModel.BuildingsType;
            buildingView.Position = buildingModel.Position;
        }
    }
}