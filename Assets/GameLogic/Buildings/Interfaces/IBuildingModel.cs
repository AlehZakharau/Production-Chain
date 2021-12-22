using UnityEngine;

namespace GameLogic.Buildings.Interfaces
{
    public interface IBuildingModel
    {
        public BuildingsType BuildingsType { get; set; }
        
        public Vector3 Position { get; set; }
    }
}