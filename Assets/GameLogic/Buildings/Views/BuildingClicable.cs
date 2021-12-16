using GameLogic.CameraController;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public class BuildingClicable : MonoBehaviour, IClickable
    {
        [SerializeField] private GameObject hidPanel;
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