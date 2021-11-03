// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace DefaultNamespace.Transport
// {
//     public interface ITransportView
//     {
//         public event Action OnDestroy;
//         public Vector3 SenderPosition { get; set; }
//         
//         public Vector3 ReceiverPosition { get; set; }
//
//         public void CreateBridge();
//     }
//     public class TransportView : MonoBehaviour, ITransportView
//     {
//         //[SerializeField] private GameObject bridge;
//
//         private bool isSelected;
//         public event Action OnDestroy;
//         public Vector3 SenderPosition { get; set; }
//         public Vector3 ReceiverPosition { get; set; }
//
//         private Material baseMaterial;
//
//         private Color baseColor;
//
//
//         private void Awake()
//         {
//             baseMaterial = GetComponentInChildren<MeshRenderer>().material;
//             baseColor = baseMaterial.color;
//         }
//
//
//         public void CreateBridge()
//         {
//             //var instance = Instantiate(bridge);
//             transform.position = SenderPosition + 0.5f * (ReceiverPosition - SenderPosition);
//             var target = ReceiverPosition - SenderPosition;
//             target.Normalize();
//             var targetAngle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90;
//             transform.Rotate(Vector3.forward, targetAngle);
//             var distance = Vector3.Distance(SenderPosition, ReceiverPosition);
//             transform.localScale = new Vector3(1, distance, 1);
//         }
//
//         private void OnMouseDown()
//         {
//             if (isSelected)
//             {
//                 isSelected = false;
//                 baseMaterial.color = baseColor;
//             }
//             else
//             {
//                 isSelected = true;
//                 baseMaterial.color = Color.yellow;
//             }
//             
//         }
//
//         private void Update()
//         {
//             if (!isSelected) return;
//             if (Input.GetMouseButtonDown(1))
//             {
//                 OnDestroy?.Invoke();
//                 Destroy(gameObject);
//                 //Delete Model, Controller and fabrics
//                 // or GC destroy it by itself
//             }
//         }
//
//         private void ShowSelected()
//         {
//             baseMaterial.color = Color.yellow;
//         }
//     }
// }