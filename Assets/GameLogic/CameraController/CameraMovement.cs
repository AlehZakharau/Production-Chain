using System;
using UnityEngine;

namespace GameLogic
{
    public class CameraMovement : MonoBehaviour
    { 
        private PlayerInput playerInput;

        [SerializeField] private float speedButtons = 2f;
        [SerializeField] private float speedMouse = 2f;

        [SerializeField] private int boundary = 1;

        private int width;
        private int height;

        private void Awake()
        {
            playerInput = new PlayerInput();
            playerInput.Enable();

            width = Screen.width;
            height = Screen.height;
        }

        private void Update()
        {
            var direction = playerInput.Camera.Move.ReadValue<Vector2>();
            var cursorPosition = playerInput.Camera.CursorPosition.ReadValue<Vector2>();
            
            Move(direction);
            MoveByCursor(cursorPosition);
        }

        private void Move(Vector2 direction)
        {
            var move = new Vector3(direction.x, direction.y, 0);

            transform.position += move * speedButtons * Time.deltaTime;
        }

        private void MoveByCursor(Vector2 direction)
        {
            var move = Vector3.zero;
            if (direction.x > width - boundary)
            {
                move.x += direction.x;
            }
            if (direction.x < 0 + boundary)
            {
                move.x += direction.x;
            }
            if (direction.y > height - boundary)
            {
                move.y += direction.y;
            }
            if (direction.y < 0 + boundary)
            {
                move.y += direction.y;
            }

            transform.position += move * speedMouse * Time.deltaTime;
        }
    }
}