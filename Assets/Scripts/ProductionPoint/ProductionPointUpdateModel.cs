// using System;
// using System.Collections.Generic;
// using System.Linq;
// using DefaultNamespace;
// using DefaultNamespace.ProductionPoint;
// using UnityEngine;
//
// public class ProductionPointUpdateModel
// {
//     public event Action OnUpdateReady;
//     public ProductionPointInitializeModel.Level Level { get; set; }
//     public Dictionary<ResourceType, int> DemandUpdateResources = new Dictionary<ResourceType, int>();
//     
//     public ProductionPointUpdateModel(ProductionPointInitializeModel.Level level)
//     {
//         Level = level;
//         UpdateDictionaryUpdateResources();
//     }
//
//     public void AddUpdateResources(ResourceType resource)
//     {
//         DemandUpdateResources[resource]--;
//         if (CheckUpdateStatus())
//         {
//             OnUpdateReady?.Invoke();
//         }
//     }
//
//     private bool CheckUpdateStatus()
//     {
//         return DemandUpdateResources.All(resource => resource.Value <= 0);
//     }
//     
//     private void UpdateDictionaryUpdateResources()
//     {
//         DemandUpdateResources = new Dictionary<ResourceType, int>();
//         for (int i = 0; i < Level.demandResource.Length; i++)
//         {
//             DemandUpdateResources.Add(Level.demandResource[i],Level.demandResourceCapacity[i]);
//         }
//     }
// }