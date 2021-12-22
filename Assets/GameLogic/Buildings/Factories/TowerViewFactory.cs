using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface ITowerViewFactory
    {
        public IBuildingView BuildingView { get; }
        public IBuildingClicable BuildingClicable { get; }
        public IProduceView ProduceView { get; }
        public ITowerView TowerView { get; }
        public IBuildingUpgraderView BuildingUpgraderView { get; }
    }
    [CreateAssetMenu(fileName = "TowerViewFactory", menuName = "Factories/TowerViewFactory", order = 0)]
    public class TowerViewFactory : ScriptableObject, ITowerViewFactory
    {
        [SerializeField] private BuildingView buildingView;
        public IBuildingView BuildingView { get; private set; }
        public IBuildingClicable BuildingClicable { get; private set; }
        public IProduceView ProduceView { get; private set; }
        public ITowerView TowerView { get; private set; }
        public IBuildingUpgraderView BuildingUpgraderView { get; private set; }
        
        public void Initiate(Transform parent)
        {
            var instance = Instantiate(buildingView, parent);
            BuildingView = instance.GetComponent<IBuildingView>();
            BuildingUpgraderView = instance.GetComponent<IBuildingUpgraderView>();
            BuildingClicable = instance.GetComponent<IBuildingClicable>();
            TowerView = instance.GetComponent<ITowerView>();
            ProduceView = instance.GetComponent<IProduceView>();
        }
    }
}