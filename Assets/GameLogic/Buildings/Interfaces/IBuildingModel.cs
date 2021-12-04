using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IBuildingModel
    {
        public BuildingsType BuildingsType { get; set; }
        
        public Vector3 Position { get; set; }
    }
}