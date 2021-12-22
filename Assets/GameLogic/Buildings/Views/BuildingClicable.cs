using System;
using GameLogic.CameraController;
using UnityEngine;

namespace GameLogic.Buildings.Views
{
    public interface IBuildingClicable
    {
        public event Action OnClick;
        public Transform parent { get; set; }
    }
    public class BuildingClicable : MonoBehaviour, IClickable, IBuildingClicable
    {
        [SerializeField] private GameObject hidPanel;
        public event Action OnClick;
        public Transform parent { get; set; }

        private void OnEnable()
        {
            parent = transform;
        }


        public void Click()
        {
            OnClick?.Invoke();
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