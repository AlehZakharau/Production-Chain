using System;
using GameLogic;
using GameLogic.CameraController;
using UnityEngine;

namespace CommonBaseUI.UIController
{
    public class UIKeywordInputView : MonoBehaviour
    {
        public event Action OnCloseButtonPressed;

        private PlayerInput playerInput;

        private void Start()
        {
            playerInput = PlayerInputInstance.Instance.PlayerInput;
        }

        private void Update()
        {
            var buttonPressed = playerInput.Camera.CloseMenu.triggered;
        
            Debug.Log($"Esc: {buttonPressed}");
            if(buttonPressed)
            {
                OnCloseButtonPressed?.Invoke();
            }
        }

        
    }
}