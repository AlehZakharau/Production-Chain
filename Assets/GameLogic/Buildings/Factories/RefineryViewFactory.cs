using GameLogic.Buildings.Views;
using UnityEngine;

namespace GameLogic.Buildings.Factories
{
    public interface IRefineryViewFactory
    {
        IBuildingView BuildingView { get; }
        IBuildingUpgraderView BuildingUpgraderView { get; }
        IBuildingClicable BuildingClicable { get; }
        IManufactureView ManufactureView { get; }
        IRefineryProduceStorageView RefineryProduceStorageView { get; }
        IProduceView ProduceView{ get;}
        
    }
    [CreateAssetMenu(fileName = "RefineryViewFactory", menuName = "Factories/RefineryViewFactory", order = 0)]
    public class RefineryViewFactory : ScriptableObject, IRefineryViewFactory
    {
        [SerializeField]private BuildingView buildingView;
        public IBuildingView BuildingView { get; private set; }
        public IBuildingUpgraderView BuildingUpgraderView { get; private set; }
        public IBuildingClicable BuildingClicable { get; private set; }
        public IManufactureView ManufactureView { get; private set; }
        public IRefineryProduceStorageView RefineryProduceStorageView { get; private set; }
        public IProduceView ProduceView { get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(buildingView, parent);
            BuildingView = instance.GetComponent<IBuildingView>();
            BuildingUpgraderView = instance.GetComponent<IBuildingUpgraderView>();
            BuildingClicable = instance.GetComponent<IBuildingClicable>();
            ManufactureView = instance.GetComponent<IManufactureView>();
            RefineryProduceStorageView = instance.GetComponent<IRefineryProduceStorageView>();
            ProduceView = instance.GetComponent<IProduceView>();
        }
    }
}