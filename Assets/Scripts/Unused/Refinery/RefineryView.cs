// using System;
// using DefaultNamespace;
// using TMPro;
// using UnityEngine;
//
// namespace Refinery
// {
//     public interface IRefineryView
//     {
//         public event Action OnProducing;
//         ResourceType ResourceType { set; }
//         int ResourceItem { set; }
//
//         float ProducingSpeed { set; }
//         
//         RefineryType RefineryType { set; }
//         
//         Vector3 Position { set; }
//         
//         Color RefineryColor { set; }
//         
//         
//         ResourceType[] DemandResources { get; set; }
//
//         void ChangeDemandText();
//     }
//     
//     public class RefineryView : MonoBehaviour, IRefineryView
//     {
//         [SerializeField] private TMP_Text resourceTypeText;
//         [SerializeField] private TMP_Text amountText;
//         [SerializeField] private TMP_Text refineryTypeText;
//         [SerializeField] private TMP_Text demandResources;
//         [SerializeField] private Material material;
//
//         public event Action OnProducing;
//         public ResourceType ResourceType { set => resourceTypeText.text = value.ToString(); }
//         public int ResourceItem { set => amountText.text = value.ToString(); }
//
//         public float ProducingSpeed { get; set; }
//         public RefineryType RefineryType {set => refineryTypeText.text = value.ToString(); }
//         public Vector3 Position {  set => transform.position = value; }
//         public Color RefineryColor { set =>
//             GetComponentInChildren<MeshRenderer>().material.color = value; }
//         public ResourceType[] DemandResources { get; set; }
//
//         public void ChangeDemandText()
//         {
//             var text = "";
//             foreach (var resource in DemandResources)
//             {
//                 text += $"{resource.ToString() } ";
//             }
//             demandResources.text = text;
//         }
//         
//         private float timer;
//         private void Update()
//         {
//             timer += Time.deltaTime;
//             if (timer > ProducingSpeed)
//             {
//                 timer = 0;
//                 OnProducing?.Invoke();
//             }
//         }
//     }
// }