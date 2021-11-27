using System;
using UnityEngine;

namespace GameLogic
{
    class Clicker : MonoBehaviour
    {
        [SerializeField]private Camera camera;

        private IClickable currentObject;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentObject?.UnSelect();
                var layerMask = 1 << 6 | 1<< 7;
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
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