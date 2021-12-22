using GameLogic.Buildings.Controllers;
using GameLogic.Buildings.DataBase;
using GameLogic.Buildings.Models;
using GameLogic.Buildings.Models.ManufactoryModels;
using GameLogic.Manufacture;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic.Buildings.Factories
{
    public class BuildingBuilder : MonoBehaviour
    {
        [SerializeField] private BuildingViewFactory buildingViewFactory;
        [SerializeField] private RefineryViewFactory refineryViewFactory;
        [SerializeField] private ExtractorViewFactory extractorViewFactory;
        
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
                    var extractorProduceModel = new ExtractorProduceModel();
                    var extractorResourceStorage = new ResourceStorage( 
                        buildingModel, buildingUpgraderModel, transportationService);
                    var extractorModel = new ManufactureModel(buildingModel, 
                        extractorResourceStorage, extractorProduceModel, buildingUpgraderModel, 
                        initData.ManufactureInitData, transportationService);
                    Tick.Tickable.Add(extractorModel);
                    
                    //Views
                    extractorViewFactory.Initiate(parent);
                    var extractorBuildingClicable = extractorViewFactory.BuildingClicable;
                    var extractorBuildingView = extractorViewFactory.BuildingView;
                    var extractorBuildingUpgradeView = extractorViewFactory.BuildingUpgraderView;
                    var extractorProduceView = extractorViewFactory.ProduceView;
                    var extractorView = extractorViewFactory.ManufactureView;

                    //Controllers
                    var extractorBuildingController = new BuildingController(buildingUpgraderModel,
                        extractorBuildingUpgradeView,
                        buildingModel, extractorBuildingView);
                    var extractorProduceController = new ProduceController(extractorProduceModel,
                        extractorProduceView);
                    var extractorController = new ManufactureController(
                        extractorModel, extractorView, extractorBuildingClicable, extractorResourceStorage);
                    break;
                case BuildingsType.Refinery:
                    //Models
                    var refineryProduceStorageModel = new RefineryProduceStorageModel(initData.RefineryInitData);
                    var refineryProduceModel = new RefineryProduceModel(refineryProduceStorageModel);
                    var refineryResourceStorage = new RefineryResourceStorage(buildingModel, 
                        buildingUpgraderModel, refineryProduceStorageModel);
                    var refineryModel = new ManufactureModel(buildingModel,
                        refineryResourceStorage, refineryProduceModel, buildingUpgraderModel, 
                        initData.ManufactureInitData, transportationService);
                    Tick.Tickable.Add(refineryModel);
                    
                    //Views
                    refineryViewFactory.Initiate(parent);
                    var refineryBuildingClicable = refineryViewFactory.BuildingClicable;
                    var refineryBuildingView = refineryViewFactory.BuildingView;
                    var refineryBuildingUpgradeView = refineryViewFactory.BuildingUpgraderView;
                    var refineryProduceStorageView = refineryViewFactory.RefineryProduceStorageView;
                    var refineryProduceView = refineryViewFactory.ProduceView;
                    var refineryView = refineryViewFactory.ManufactureView;
                    
                    //Controllers
                    var refineryProduceController = new ProduceController(refineryProduceModel,
                        refineryProduceView);
                    var refineryBuildingController = new BuildingController(buildingUpgraderModel,
                        refineryBuildingUpgradeView,
                        buildingModel, refineryBuildingView);
                    var refineryProduceStorageController = new RefineryProduceStorageController(
                        refineryProduceStorageModel,
                        refineryProduceStorageView, refineryBuildingClicable);
                    var refineryController = new ManufactureController(
                        refineryModel, refineryView, buildingViewFactory.BuildingClicable, refineryResourceStorage);
                    break;
                case BuildingsType.Tower:
                    //Models
                    var towerBuildingModel = new TowerModel(buildingUpgraderModel);
                    
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