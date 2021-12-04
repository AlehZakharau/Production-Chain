using UnityEngine;

namespace GameLogic.Manufacture
{
    public class BuildingBuilder : MonoBehaviour
    {
        [SerializeField] private BuildingViewFactory buildingViewFactory;
        [SerializeField] private RefineryProduceStorageViewFactory refineryProduceStorageViewFactory;
        [SerializeField] private ResourceStorageViewFactory resourceStorageViewFactory;
        
        [SerializeField] private Tick tick;

        public void CreateBuilding(BuildingInitData initData)
        {
            var parent = initData.transform;
            var buildingUpgraderModel = new BuildingUpgraderModel(initData.LevelInitData);
            switch (initData.InitData.buildingsType)
            {
                case BuildingsType.Extractor:
                    var extractorResourceStorageModel = new ResourceStorageModel(buildingUpgraderModel);
                    var extractorBuildingModel = new ManufactureModel(extractorResourceStorageModel, buildingUpgraderModel,
                        initData.InitData, initData.ManufactureInitData);
                    tick.Tickable.Add(extractorBuildingModel);
                    
                    buildingViewFactory.Initiate(parent);
                    var extractorBuildingView = buildingViewFactory.BuildingView;
                    var extractorBuildingUpgradeView = buildingViewFactory.BuildingUpgraderView;
                    resourceStorageViewFactory.Initiate(parent);
                    var extractorResourceStorageView = resourceStorageViewFactory.ResourceStorageView;

                    var extractorBuildingController = new BuildingController(buildingUpgraderModel,
                        extractorBuildingUpgradeView,
                        extractorBuildingModel, extractorBuildingView);
                    var extractorResourceStorage = new ResourceStorageController(extractorResourceStorageModel,
                        extractorResourceStorageView);
                    break;
                case BuildingsType.Refinery:
                    var refineryProduceStorageModel = new RefineryProduceStorageModel(initData.RefineryInitData);
                    var refineryResourceStorageModel = new RefineryResourceStorageModel(buildingUpgraderModel, 
                            refineryProduceStorageModel);
                    var refineryBuildingModel = new ManufactureModel(refineryResourceStorageModel, buildingUpgraderModel,
                        initData.InitData, initData.ManufactureInitData);
                    tick.Tickable.Add(refineryBuildingModel);
                    
                    buildingViewFactory.Initiate(parent);
                    var refineryBuildingView = buildingViewFactory.BuildingView;
                    var refineryBuildingUpgradeView = buildingViewFactory.BuildingUpgraderView;
                    resourceStorageViewFactory.Initiate(parent);
                    var refineryResourceStorageView = resourceStorageViewFactory.ResourceStorageView;
                    refineryProduceStorageViewFactory.Initiate(parent);
                    var refineryProduceStorageView = refineryProduceStorageViewFactory.RefineryProduceStorageView;
                    
                    var refineryBuildingController = new BuildingController(buildingUpgraderModel,
                        refineryBuildingUpgradeView,
                        refineryBuildingModel, refineryBuildingView);
                    var refineryResourceStorage = new ResourceStorageController(refineryResourceStorageModel,
                        refineryResourceStorageView);
                    var refineryProduceStorageController = new RefineryProduceStorageController(
                        refineryProduceStorageModel,
                        refineryProduceStorageView);
                    break;
                case BuildingsType.Tower:
                    var towerBuildingModel = new TowerModel(buildingUpgraderModel,
                        initData.InitData);
                    
                    buildingViewFactory.Initiate(parent);
                    var towerBuildingView = buildingViewFactory.BuildingView;
                    var towerBuildingUpgradeView = buildingViewFactory.BuildingUpgraderView;
                    
                    var towerBuildingController = new BuildingController(buildingUpgraderModel,
                        towerBuildingUpgradeView,
                        towerBuildingModel, towerBuildingView);
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