// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using DefaultNamespace.Transport;
// using UnityEngine;
// using static DefaultNamespace.ProductionPoint.ProductionPointInitializeModel;
//
// namespace DefaultNamespace.ProductionPoint
// {
//     public interface IProductionPointModel
//     {
//         public event Action OnProducingResource;
//         public event Action<IProductionPointModel> OnClick;
//         
//         public ProductionPointType ProductionPointType { get; set; }
//         
//         public ResourceType ProducingResourceType { get; set; }
//         
//         public int ProducingResource { get; set; }
//         
//         public Dictionary<ResourceType, int> DemandResources { get; set; }
//         
//         public ResourceType[] DemandResourceTypes { get; set; }
//         
//         public Vector3 Position { get; set; }
//         
//         public float ProductionSpeed { get; set; }
//         
//         bool Extractor { get; set; }
//
//         public ITransportModel TransportModel { get; set; }
//         
//         //public List<IUpdateLevel> UpdateLevels { get; set; }
//         
//         public ProductionPointUpdateModel ProductionPointUpdateModel { get; set; }
//
//         public void Initiate(InitializeData initializeData, Level[] initializeDataLevelData);
//
//         public void AddDemandResources(ResourceType resourceType);
//
//         public void CallTransportService(IProductionPointModel model);
//
//         public void Tick();
//
//     }
//     public class ProductionPointModel : IProductionPointModel
//     {
//         private int resource;
//         private float timer;
//         
//         public event Action OnProducingResource;
//         public event Action<IProductionPointModel> OnClick;
//         public ProductionPointType ProductionPointType { get; set; }
//         public ResourceType ProducingResourceType { get; set; }
//
//         public int ProducingResource
//         {
//             get => resource;
//             set
//             { 
//                 if(resource == value) return;
//                 {
//                     resource = value;
//                     OnProducingResource?.Invoke();
//                 }
//             }
//         }
//
//         public Dictionary<ResourceType, int> DemandResources { get; set; } = new Dictionary<ResourceType, int>();
//         public ResourceType[] DemandResourceTypes { get; set; }
//         public Vector3 Position { get; set; }
//         public float ProductionSpeed { get; set; }
//         public bool Extractor { get; set; }
//         public ITransportModel TransportModel { get; set; }
//         //public List<IUpdateLevel> UpdateLevels { get; set; }
//
//         public Level[] levels = new Level[3];
//         public int currentLevel;
//         public ProductionPointUpdateModel ProductionPointUpdateModel { get; set; }
//
//
//         public void Initiate(InitializeData initializeData, Level[] levelsData)
//         {
//             ProductionPointType = initializeData.productionPointType;
//             ProducingResourceType = initializeData.resourceType;
//             ProductionSpeed = initializeData.productionSpeed;
//             Position = initializeData.spawnPosition.position;
//             DemandResourceTypes = initializeData.demandResources;
//             Extractor = initializeData.extractor;
//             AddDemandResources(initializeData.demandResources);
//             
//             ProductionPointUpdateModel = new ProductionPointUpdateModel(levelsData[currentLevel]);
//             levels = levelsData;
//         }
//         private void AddDemandResources(ResourceType[] demandResources)
//         {
//             foreach (var resourceType in demandResources)
//             {
//                 if (!DemandResources.ContainsKey(resourceType))
//                 {
//                     DemandResources.Add(resourceType, 0);
//                 }
//             }
//         }
//
//         public void AddDemandResources(ResourceType resourceType)
//         {
//             if (ProductionPointUpdateModel.DemandUpdateResources.ContainsKey(resourceType))
//             {
//                 ProductionPointUpdateModel.AddUpdateResources(resourceType);
//             }
//             else
//             {
//                 DemandResources[resourceType]++;
//             }
//         }
//
//         private void UpdateProductionPoint()
//         {
//             currentLevel++;
//             ProductionPointUpdateModel = new ProductionPointUpdateModel(levels[currentLevel]);
//         }
//         
//         private void ProduceItem()
//         {
//             if (DemandResources.Any(
//                 varResource => varResource.Value < 1))
//             {
//                 return;
//             }
//
//             foreach (var varResource in DemandResourceTypes)
//             {
//                 DemandResources[varResource]--;
//             }
//             ProducingResource++;
//         }
//
//         public void CallTransportService(IProductionPointModel model)
//         {
//             OnClick?.Invoke(model);
//         }
//
//         public void Tick()
//         {
//             Producing();
//         }
//
//         private void Producing()
//         {
//             timer += Time.deltaTime;
//             {
//                 if (!(timer > ProductionSpeed)) return;
//                 timer = 0;
//                 if (Extractor)
//                 {
//                     ProducingResource++;
//                 }
//                 else
//                 {
//                     ProduceItem();
//                 }
//             }
//         }
//     }
// }