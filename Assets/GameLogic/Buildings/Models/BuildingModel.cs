using UnityEngine;

namespace GameLogic.Manufacture
{
    public class BuildingModel : IBuildingModel
    {
        public BuildingsType BuildingsType { get; set; }
        public Vector3 Position { get; set; }

        public BuildingModel(InitializeData.InitData initData)
        {
            BuildingsType = initData.buildingsType;
            Position = initData.Position.position;
        }
    }
}