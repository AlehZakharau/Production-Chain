using GameLogic.CameraController;
using TMPro;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IBuildingView
    {
        public BuildingsType BuildingsType { get; set; }
        
        public Vector3 Position { get; set; }
    }
    public class BuildingView : MonoBehaviour, IBuildingView, IClickable
    {
        [SerializeField] private GameObject hidPanel;
        //[SerializeField] private TMP_Text buildingTypeText;
        public BuildingsType BuildingsType { get => BuildingsType;
            set => BuildingsType = value; }

        public Vector3 Position { get => Position; 
            set => transform.position = value; }

        public void Click()
        {
            Debug.Log($"Click {this.gameObject.name}");
        }

        public void Select()
        {
            hidPanel.SetActive(true);
        }

        public void UnSelect()
        {
            hidPanel.SetActive(false);
        }
    }
}