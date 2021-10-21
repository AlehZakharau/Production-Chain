using UnityEngine;

namespace DefaultNamespace.ProductionPoint
{
    public class ProductionPointInitializeData : MonoBehaviour
    {
        [SerializeField] private ProductionPointInitializeModel.InitializeData data = 
            new ProductionPointInitializeModel.InitializeData()
            {
                productionSpeed = 1f
            };

        public ProductionPointInitializeModel.InitializeData InitializeData => data;
    }
}