using CommonBaseUI.Data;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IBuildingViewFactory
    {
        IBuildingView BuildingView { get; }
        IBuildingUpgraderView BuildingUpgraderView { get; }
    }
    
    [CreateAssetMenu(fileName = "BuildingViewFactory", 
        menuName = "SO/BuildingViewFactory", order = 0)]
    public class BuildingViewFactory : ScriptableObject, IBuildingViewFactory
    {
        [SerializeField]private BuildingView productionView;
        
        public IBuildingView BuildingView { get; private set; }
        public IBuildingUpgraderView BuildingUpgraderView { get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(productionView, parent, true);
            BuildingView = instance.GetComponent<IBuildingView>();
            BuildingUpgraderView = instance.GetComponent<IBuildingUpgraderView>();
            instance.transform.position = new Vector3(0, 0, 0);
        }
    }
}