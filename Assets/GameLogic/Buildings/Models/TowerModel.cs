using UnityEngine;

namespace GameLogic.Manufacture
{
    public class TowerModel : IBuildingModel
    {
        public BuildingsType BuildingsType { get; set; }
        public Vector3 Position { get; set; }
        
        private readonly IBuildingUpgraderModel buildingUpgraderModel;
        
        public TowerModel(IBuildingUpgraderModel buildingUpgraderModel,
            InitializeData.InitData initData)
        {
            this.buildingUpgraderModel = buildingUpgraderModel;

            BuildingsType = initData.buildingsType;
            Position = initData.Position.position;
            
            buildingUpgraderModel.OnUpgrade += OnUpgrade;
        }

        private void OnUpgrade()
        {
            // Open new Area
            throw new System.NotImplementedException();
        }
    }
}