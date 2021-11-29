using System;
using UnityEngine;

namespace GameLogic
{
    class Clicker : MonoBehaviour
    {
        [SerializeField]private Camera camera;
        [SerializeField] private PlayerInputInstance playerInputI;
        private PlayerInput playerInput;

        private IClickable currentObject;

        private void Start()
        {
            playerInput = playerInputI.PlayerInput;
        }

        private void Update()
        {
            var clicked= playerInput.Camera.Click.triggered;
            var cursorPosition = playerInput.Camera.CursorPosition.ReadValue<Vector2>();

            if (clicked)
            {
                currentObject?.UnSelect();
                var layerMask = 1 << 6 | 1<< 7;
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                Ray ray = camera.ScreenPointToRay(cursorPosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    currentObject = hit.collider.GetComponent<IClickable>();
                    currentObject.Select();
                    currentObject.Click();
                }
            }
        }
    }


    interface IClickable
    {
        public void Click();

        public void Select();

        public void UnSelect();
    }
}