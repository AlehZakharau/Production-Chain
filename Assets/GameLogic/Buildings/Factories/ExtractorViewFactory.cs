using GameLogic.Buildings.Views;
using UnityEngine;

namespace GameLogic.Buildings.Factories
{
    public interface IExtractorViewFactory
    {
        IBuildingView BuildingView { get; }
        IBuildingUpgraderView BuildingUpgraderView { get; }
        IBuildingClicable BuildingClicable { get; }
        IProduceView ProduceView { get; }
        IManufactureView ManufactureView { get; }
    }
    [CreateAssetMenu(fileName = "ExtractorViewFactory", menuName = "Factories/ExtractorViewFactory", order = 0)]
    public class ExtractorViewFactory : ScriptableObject, IExtractorViewFactory
    {
        [SerializeField]private BuildingView buildingView;
        public IBuildingView BuildingView { get; private set; }
        public IBuildingUpgraderView BuildingUpgraderView { get; private set; }
        public IBuildingClicable BuildingClicable { get; private set; }
        public IManufactureView ManufactureView { get; private set; }
        public IProduceView ProduceView{ get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(buildingView, parent);
            BuildingView = instance.GetComponent<IBuildingView>();
            BuildingUpgraderView = instance.GetComponent<IBuildingUpgraderView>();
            BuildingClicable = instance.GetComponent<IBuildingClicable>();
            ManufactureView = instance.GetComponent<IManufactureView>();
            ProduceView = instance.GetComponent<IProduceView>();
        }
    }
}