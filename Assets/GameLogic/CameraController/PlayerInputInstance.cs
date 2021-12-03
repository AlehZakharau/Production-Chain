using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

namespace GameLogic
{
    public class PlayerInputInstance : MonoBehaviour
    {
        public static PlayerInputInstance Instance;
        public PlayerInput PlayerInput { get; private set; }
        private void Awake()
        {
            Instance = this;
            PlayerInput = new PlayerInput();
            
            PlayerInput.Enable();
        }
    }
}