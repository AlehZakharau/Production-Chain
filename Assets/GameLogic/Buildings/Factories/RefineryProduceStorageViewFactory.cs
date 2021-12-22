using GameLogic.Buildings.Views;
using UnityEngine;

namespace GameLogic.Buildings.Factories
{
    public interface IRefineryProduceStorageViewFactory
    {
        public IRefineryProduceStorageView RefineryProduceStorageView { get; }
    }
    [CreateAssetMenu(fileName = "RefineryProduceStorageView", 
        menuName = "Factories/RefineryProduceStorageView", order = 0)]
    public class RefineryProduceStorageViewFactory : ScriptableObject, IRefineryProduceStorageViewFactory
    {
        [SerializeField] private RefineryProduceStorageView refineryProduceStorageView;
        public IRefineryProduceStorageView RefineryProduceStorageView { get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(refineryProduceStorageView, parent);
            RefineryProduceStorageView = instance.GetComponent<IRefineryProduceStorageView>();
        }
    }
}