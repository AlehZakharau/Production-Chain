// using UnityEngine;
//
// namespace DefaultNamespace.ProductionPoint
// {
//     public interface IProductionPointController
//     {
//         
//     }
//     public class ProductionPointController : IProductionPointController
//     {
//         private readonly IProductionPointModel model;
//         private readonly IProductionPointView view;
//
//         public ProductionPointController(IProductionPointModel model,
//             IProductionPointView view)
//         {
//             this.model = model;
//             this.view = view;
//             
//             model.OnProducingResource += ModelOnOnProducingResource;
//
//             view.onClick += SyncClick;
//             
//             SyncProducing();
//             
//             Initial();
//         }
//
//         private void Initial()
//         {
//             view.Position = model.Position;
//             view.ProducingResourceType = model.ProducingResourceType;
//             view.DemandResourceTypes = model.DemandResourceTypes;
//             view.ProductionPointType = model.ProductionPointType;
//         }
//
//         private void ModelOnOnProducingResource()
//         {
//             SyncProducing();
//         }
//
//         private void SyncProducing()
//         {
//             view.ProducingResource = model.ProducingResource;
//         }
//
//         private void SyncClick()
//         {
//             model.CallTransportService(model);
//         }
//     }
// }