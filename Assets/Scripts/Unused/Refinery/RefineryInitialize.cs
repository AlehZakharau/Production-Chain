// using System.Collections;
// using UnityEngine;
//
// namespace Refinery
// {
//     public class RefineryInitialize : MonoBehaviour
//     {
//         [SerializeField] private RefineryViewFactory viewFactory;
//
//         [SerializeField] private RefineryInitializeData[] initData;
//         
//         
//         private void Awake()
//         {
//
//             foreach (var initializeData in initData)
//             {
//                 var modelFactory = new RefineryModelFactory();
//                 var model = modelFactory.Model;
//                 model.Initialize(initializeData.InitializeData);
//
//                 viewFactory.Initiate();
//                 var view = viewFactory.View;
//                 
//  
//                 var controllerFactory = new RefineryControllerFactory(model, view);
//                 var controller = controllerFactory.Controller;
//             }
//             
//             //StartCoroutine(Producing(model));
//         }
//
//         private IEnumerator Producing(IRefineryModel model)
//         {
//             while (true)
//             {
//                 yield return new WaitForSeconds(1);
//
//                 model.ResourceItem++;
//             }
//         }
//     }
// }