using UnityEngine;

namespace GameLogic.CameraController
{
    [RequireComponent(typeof(Camera))]
    public sealed class MouseClicker : MonoBehaviour
    {
        private Camera camera;
        private PlayerInput playerInput;
        private IClickable currentObject;

        private int clicableMask;

        private void Start()
        {
            camera = GetComponent<Camera>();
            playerInput = PlayerInputInstance.Instance.PlayerInput;
            clicableMask = LayerMask.GetMask("Manufacture");
        }

        private void Update()
        {
            var clicked= playerInput.Camera.Click.triggered;
            var cursorPosition = playerInput.Camera.CursorPosition.ReadValue<Vector2>();

            if (clicked)
            {
                currentObject?.UnSelect();
                Ray ray = camera.ScreenPointToRay(cursorPosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clicableMask))
                {
                    if (hit.collider.TryGetComponent(out IClickable clickable))
                    {
                        currentObject = clickable;
                        currentObject.Select();
                        currentObject.Click();
                    };
                }
            }
        }
    }
}