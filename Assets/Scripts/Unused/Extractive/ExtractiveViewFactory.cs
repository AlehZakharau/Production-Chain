// using UnityEngine;
//
// namespace Extractive
// {
//     public interface IExtractiveViewFactory
//     {
//         IExtractiveView View { get; }
//     }
//     
//     [CreateAssetMenu(fileName = "ExtractiveViewFactory", menuName = "SO/ExtractiveViewFactory", order = 0)]
//     public class ExtractiveViewFactory : ScriptableObject
//     {
//         public ExtractiveView extractiveView;
//         
//         public IExtractiveView View { get; private set; }
//
//         public void Initiate()
//         {
//             var instance = Instantiate(extractiveView);
//             View = instance.GetComponent<IExtractiveView>();
//             instance.transform.position = new Vector3(0, 0, 0);
//         }
//     }
//     
//     public interface IExtractiveControllerFactory
//     {
//         IExtractiveController Controller { get; }
//     }
//     
//     public class ExtractiveControllerFactory : IExtractiveControllerFactory
//     {
//         public IExtractiveController Controller { get; }
//
//         public ExtractiveControllerFactory(IExtractiveModel model, IExtractiveView view)
//         {
//             Controller = new ExtractiveController(model, view);
//         }
//     }
//     
//     public interface IExtractiveModelFactory
//     {
//         IExtractiveModel Model { get; }
//     }
//     
//     public class ExtractiveModelFactory : IExtractiveModelFactory
//     {
//         public IExtractiveModel Model { get; }
//
//         public ExtractiveModelFactory()
//         {
//             Model = new ExtractiveModel();
//         }
//     }
// }