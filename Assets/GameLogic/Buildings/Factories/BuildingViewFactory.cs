using GameLogic.Buildings.Views;
using UnityEngine;

namespace GameLogic.Buildings.Factories
{
    public interface IBuildingViewFactory
    {
        IBuildingView BuildingView { get; }
        IBuildingUpgraderView BuildingUpgraderView { get; }
        IBuildingClicable BuildingClicable { get; }
    }
    
    [CreateAssetMenu(fileName = "BuildingViewFactory", 
        menuName = "Factories/BuildingViewFactory", order = 0)]
    public class BuildingViewFactory : ScriptableObject, IBuildingViewFactory
    {
        [SerializeField]private BuildingView buildingView;
        
        public IBuildingView BuildingView { get; private set; }
        public IBuildingUpgraderView BuildingUpgraderView { get; private set; }
        public IBuildingClicable BuildingClicable { get; private set; }
        public void Initiate(Transform parent)
        {
            var instance = Instantiate(buildingView, parent);
            BuildingView = instance.GetComponent<IBuildingView>();
            BuildingUpgraderView = instance.GetComponent<IBuildingUpgraderView>();
            BuildingClicable = instance.GetComponent<IBuildingClicable>();
        }
    }
}