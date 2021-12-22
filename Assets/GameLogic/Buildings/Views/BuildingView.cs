using UnityEngine;

namespace GameLogic.Buildings.Views
{
    public interface IBuildingView
    {
        public BuildingsType BuildingsType { get; set; }
        
        public Vector3 Position { get; set; }
        
    }
    public class BuildingView : MonoBehaviour, IBuildingView
    {
        //[SerializeField] private TMP_Text buildingTypeText;
        public BuildingsType BuildingsType { get; set; }

        public Vector3 Position { get => Position; 
            set => transform.position = value; }
        
    }
}