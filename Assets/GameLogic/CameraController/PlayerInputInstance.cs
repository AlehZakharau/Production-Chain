using System;
using UnityEngine;

namespace GameLogic
{
    public class PlayerInputInstance : MonoBehaviour
    {
        
        public PlayerInput PlayerInput { get; private set; }
        private void Awake()
        {
            PlayerInput = new PlayerInput();
            
            PlayerInput.Enable();
        }
    }
}