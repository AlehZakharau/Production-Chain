using GameLogic.Transport;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public class BuildingBuilder : MonoBehaviour
    {
        [SerializeField] private BuildingViewFactory buildingViewFactory;
        [SerializeField] private RefineryViewFactory refineryViewFactory;
        [SerializeField] private ExtractorViewFactory extractorViewFactory;
        [SerializeField] private ManufactureViewFactory manufactureViewFactory;
        [SerializeField] private RefineryProduceStorageViewFactory refineryProduceStorageViewFactory;
        [SerializeField] private ResourceStorageViewFactory resourceStorageViewFactory;
        
        private TransportationService transportationService;
        public void CreateBuilding(BuildingInitData initData, TransportationService transportationService)
        {
            this.transportationService = transportationService;
            var parent = initData.transform;
            var buildingUpgraderModel = new BuildingUpgraderModel(initData.LevelInitData, initData.InitData);
            var buildingModel = new BuildingModel(initData.InitData);
            switch (initData.InitData.buildingsType)
            {
                case BuildingsType.Extractor:
                    //Models
                    var extractorResourceStorageModel = new ResourceStorageModel( 
                        buildingModel, buildingUpgraderModel, transportationService);
                    var extractorModel = new ManufactureModel(buildingModel, 
                        extractorResourceStorageModel, buildingUpgraderModel, 
                        initData.ManufactureInitData, transportationService);
                    Tick.Tickable.Add(extractorModel);
                    
                    //Views
                    extractorViewFactory.Initiate(parent);
                    var extractorBuildingClicable = extractorViewFactory.BuildingClicable;
                    var extractorBuildingView = extractorViewFactory.BuildingView;
                    var extractorBuildingUpgradeView = extractorViewFactory.BuildingUpgraderView;
                    var extractorResourceStorageView = extractorViewFactory.ResourceStorageView;
                    var extractorView = extractorViewFactory.ManufactureView;

                    //Controllers
                    var extractorBuildingController = new BuildingController(buildingUpgraderModel,
                        extractorBuildingUpgradeView,
                        buildingModel, extractorBuildingView);
                    var extractorResourceStorage = new ResourceStorageController(extractorResourceStorageModel,
                        extractorResourceStorageView, extractorBuildingClicable);
                    var extractorController = new ManufactureController(
                        extractorModel, extractorView, extractorBuildingClicable);
                    break;
                case BuildingsType.Refinery:
                    //Models
                    var refineryProduceStorageModel = new RefineryProduceStorageModel(initData.RefineryInitData);
                    var refineryResourceStorageModel = new RefineryResourceStorageModel(buildingModel, 
                        buildingUpgraderModel, refineryProduceStorageModel, transportationService);
                    var refineryModel = new ManufactureModel(buildingModel,
                        refineryResourceStorageModel, buildingUpgraderModel, 
                        initData.ManufactureInitData, transportationService);
                    Tick.Tickable.Add(refineryModel);
                    
                    //Views
                    refineryViewFactory.Initiate(parent);
                    var refineryBuildingClicable = refineryViewFactory.BuildingClicable;
                    var refineryBuildingView = refineryViewFactory.BuildingView;
                    var refineryBuildingUpgradeView = refineryViewFactory.BuildingUpgraderView;
                    var refineryProduceStorageView = refineryViewFactory.RefineryProduceStorageView;
                    var refineryView = refineryViewFactory.ManufactureView;
                    
                    //Controllers
                    var refineryBuildingController = new BuildingController(buildingUpgraderModel,
                        refineryBuildingUpgradeView,
                        buildingModel, refineryBuildingView);
                    var refineryProduceStorageController = new RefineryProduceStorageController(
                        refineryProduceStorageModel,
                        refineryProduceStorageView, refineryBuildingClicable);
                    var refineryController = new ManufactureController(
                        refineryModel, refineryView, buildingViewFactory.BuildingClicable);
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