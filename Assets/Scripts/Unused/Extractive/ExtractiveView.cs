// using System;
// using System.Timers;
// using DefaultNamespace;
// using TMPro;
// using UnityEngine;
//
// namespace Extractive
// {
//     public interface IExtractiveView
//     {
//         public event Action OnProducing;
//         
//         ResourceType ResourceType { set; }
//         int ResourceItem {  set; }
//         float ProducingSpeed { get; set; }
//         ExtractiveType ExtractiveType { set; }
//         Vector3 Position { set; }
//         Color ExtractiveColor { set; }
//     }
//     
//     public class ExtractiveView : MonoBehaviour, IExtractiveView
//     {
//         [SerializeField] private TMP_Text resourceTypeText;
//         [SerializeField] private TMP_Text amountText;
//         [SerializeField] private TMP_Text extractiveTypeText;
//         [SerializeField] private Material material;
//
//         public event Action OnProducing;
//
//         public ResourceType ResourceType
//         {
//             set => resourceTypeText.text = value.ToString();
//         }
//         public int ResourceItem { set => amountText.text = value.ToString(); }
//         public float ProducingSpeed { get; set; }
//
//         public ExtractiveType ExtractiveType
//         {
//             set => extractiveTypeText.text = value.ToString();
//         }
//         public Vector3 Position { set => transform.position = value; }
//         public Color ExtractiveColor
//         {
//             set =>
//                 GetComponentInChildren<MeshRenderer>().material.color = value;
//         }
//
//         
//         private float timer;
//         // private void Update()
//         // {
//         //     timer += Time.deltaTime;
//         //     if (timer > ProducingSpeed)
//         //     {
//         //         timer = 0;
//         //         OnProducing?.Invoke();
//         //     }
//         // }
//     }
// }