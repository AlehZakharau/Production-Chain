using UnityEngine;

namespace GameLogic.Manufacture
{
    public class BuildingBuilder : MonoBehaviour
    {
        [SerializeField] private BuildingViewFactory buildingViewFactory;
        [SerializeField] private ManufactureViewFactory manufactureViewFactory;
        [SerializeField] private RefineryProduceStorageViewFactory refineryProduceStorageViewFactory;
        [SerializeField] private ResourceStorageViewFactory resourceStorageViewFactory;

        public void CreateBuilding(BuildingInitData initData)
        {
            var parent = initData.transform;
            var buildingUpgraderModel = new BuildingUpgraderModel(initData.LevelInitData, initData.InitData);
            var buildingModel = new BuildingModel(initData.InitData);
            switch (initData.InitData.buildingsType)
            {
                case BuildingsType.Extractor:
                    //Models
                    var extractorResourceStorageModel = new ResourceStorageModel(buildingUpgraderModel);
                    var extractorModel = new ManufactureModel(extractorResourceStorageModel, 
                        buildingUpgraderModel, initData.ManufactureInitData);
                    Tick.Tickable.Add(extractorModel);
                    
                    //Views
                    buildingViewFactory.Initiate(parent);
                    var extractorBuildingView = buildingViewFactory.BuildingView;
                    var extractorBuildingUpgradeView = buildingViewFactory.BuildingUpgraderView;
                    resourceStorageViewFactory.Initiate(parent);
                    var extractorResourceStorageView = resourceStorageViewFactory.ResourceStorageView;
                    manufactureViewFactory.Initiate(parent);
                    var extractorView = manufactureViewFactory.ManufactureView;

                    //Controllers
                    var extractorBuildingController = new BuildingController(buildingUpgraderModel,
                        extractorBuildingUpgradeView,
                        buildingModel, extractorBuildingView);
                    var extractorResourceStorage = new ResourceStorageController(extractorResourceStorageModel,
                        extractorResourceStorageView);
                    var extractorController = new ManufactureController(extractorModel, extractorView);
                    break;
                case BuildingsType.Refinery:
                    //Models
                    var refineryProduceStorageModel = new RefineryProduceStorageModel(initData.RefineryInitData);
                    var refineryResourceStorageModel = new RefineryResourceStorageModel(buildingUpgraderModel, 
                            refineryProduceStorageModel);
                    var refineryModel = new ManufactureModel(refineryResourceStorageModel, 
                        buildingUpgraderModel, initData.ManufactureInitData);
                    Tick.Tickable.Add(refineryModel);
                    
                    //Views
                    buildingViewFactory.Initiate(parent);
                    var refineryBuildingView = buildingViewFactory.BuildingView;
                    var refineryBuildingUpgradeView = buildingViewFactory.BuildingUpgraderView;
                    resourceStorageViewFactory.Initiate(parent);
                    var refineryResourceStorageView = resourceStorageViewFactory.ResourceStorageView;
                    refineryProduceStorageViewFactory.Initiate(parent);
                    var refineryProduceStorageView = refineryProduceStorageViewFactory.RefineryProduceStorageView;
                    manufactureViewFactory.Initiate(parent);
                    var refineryView = manufactureViewFactory.ManufactureView;
                    
                    //Controllers
                    var refineryBuildingController = new BuildingController(buildingUpgraderModel,
                        refineryBuildingUpgradeView,
                        buildingModel, refineryBuildingView);
                    var refineryResourceStorage = new ResourceStorageController(refineryResourceStorageModel,
                        refineryResourceStorageView);
                    var refineryProduceStorageController = new RefineryProduceStorageController(
                        refineryProduceStorageModel,
                        refineryProduceStorageView);
                    var refineryController = new ManufactureController(refineryModel, refineryView);
                    break;
                case BuildingsType.Tower:
                    //Models
                    var towerBuildingModel = new TowerModel(buildingUpgraderModel,
                        initData.InitData);
                    
                    //Views
                    buildingViewFactory.Initiate(parent);
                    var towerBuildingView = buildingViewFactory.BuildingView;
                    var towerBuildingUpgradeView = buildingViewFactory.BuildingUpgraderView;
                    
                    //Controllers
                    var towerBuildingController = new BuildingController(buildingUpgraderModel,
                        towerBuildingUpgradeView,
                        buildingModel, towerBuildingView);
                    break;
            }
        }
        // private BuildingController CreateBuildingController(IBuildingUpgraderModel buildingUpgraderModel,
        //     IBuildingUpgraderView buildingUpgraderView, IBuildingModel buildingModel, IBuildingView buildingView)
        // {
        //     return new BuildingController(buildingUpgraderModel,
        //         buildingUpgraderView, buildingModel, buildingView);
        // }
    }
}