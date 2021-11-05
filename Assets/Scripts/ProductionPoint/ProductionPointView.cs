// using System;
// using System.Collections;
// using TMPro;
// using UnityEngine;
//
// namespace DefaultNamespace.ProductionPoint
// {
//     public interface IProductionPointView
//     {
//         public event Action onClick;
//         public ProductionPointType ProductionPointType { get; set; }
//         public ResourceType ProducingResourceType { get; set; }
//         public int ProducingResource { get; set; }
//         public ResourceType[] DemandResourceTypes { get; set; }
//         public Vector3 Position { get; set; }
//         
//     }
//     public class ProductionPointView : MonoBehaviour, IProductionPointView
//     {
//         [SerializeField] private TMP_Text resourceTypeText;
//         [SerializeField] private TMP_Text amountText;
//         [SerializeField] private TMP_Text productionPointTypeText;
//         [SerializeField] private TMP_Text demandResources;
//         [SerializeField] private TMP_Text updateDemandResources;
//         [SerializeField] private TMP_Text levelText;
//
//
//         private bool isSelected;
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
//         public event Action onClick;
//
//         public ProductionPointType ProductionPointType { get => ProductionPointType; 
//             set => productionPointTypeText.text = value.ToString(); }
//         public ResourceType ProducingResourceType { get => ProducingResourceType;
//             set => resourceTypeText.text = value.ToString(); }
//         public int ProducingResource { get => ProducingResource; 
//             set => amountText.text = value.ToString(); }
//         public ResourceType[] DemandResourceTypes { get => DemandResourceTypes;
//             set => demandResources.text = value.ToString(); }
//         public Vector3 Position { get => Position;
//             set => transform.position = value; }
//
//         private void OnMouseDown()
//         {
//             onClick?.Invoke();
//             StartCoroutine(ShowSelectEffect());
//         }
//
//         private IEnumerator ShowSelectEffect()
//         {
//             float timer = 0;
//             baseMaterial.color = Color.yellow;
//             while (timer < 1f)
//             {
//                 timer += Time.deltaTime;
//                 baseMaterial.color = new Color(
//                     Mathf.Lerp(baseMaterial.color.r, baseColor.r, timer),
//                     Mathf.Lerp(baseMaterial.color.g, baseColor.g, timer),
//                     Mathf.Lerp(baseMaterial.color.b, baseColor.b, timer));                
//                 yield return null;
//             }
//         }
//     }
// }