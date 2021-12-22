using System;

namespace GameLogic.Buildings.Models
{
    public interface ITowerModel
    {
        public event Action OnUpgradeTower;
    }
    public class TowerModel : ITowerModel
    {
        public event Action OnUpgradeTower;
        
        private readonly IBuildingUpgraderModel buildingUpgraderModel;


        public TowerModel(IBuildingUpgraderModel buildingUpgraderModel)
        {
            this.buildingUpgraderModel = buildingUpgraderModel;

            
            buildingUpgraderModel.OnUpgrade += OnUpgrade;
        }

        private void OnUpgrade()
        {
            OnUpgradeTower?.Invoke();
        }
    }
}