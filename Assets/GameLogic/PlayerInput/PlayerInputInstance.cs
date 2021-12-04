using UnityEngine;

namespace GameLogic.CameraController
{
    public class PlayerInputInstance : MonoBehaviour
    {
        public static PlayerInputInstance Instance;
        public PlayerInput PlayerInput { get; private set; }
        private void Awake()
        {
            PlayerInput = new PlayerInput();
            PlayerInput.Enable();
            
            Instance = this;
        }
    }
}