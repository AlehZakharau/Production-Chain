using System;
using GameLogic;
using UnityEngine;

namespace CommonBaseUI.UIController
{
    public class UIKeywordInputView : MonoBehaviour
    {
        public event Action OnCloseButtonPressed;
        
        [SerializeField] private PlayerInputInstance playerInputI;

        private PlayerInput playerInput;

        private void Start()
        {
            playerInput = playerInputI.PlayerInput;
        }

        private void Update()
        {
            var buttonPressed = playerInput.Camera.CloseMenu.triggered;
        
            if(buttonPressed)
            {
                OnCloseButtonPressed?.Invoke();
            }
        }

        
    }
}