using System.Collections;
using UnityEngine;

namespace GameLogic.Transport
{
    public class TransportPoint : MonoBehaviour, IClickable
    {
        public BridgeType bridgeType;

        public bool IsMovable { get; set; }

        IEnumerator Move()
        {
            IsMovable = true;
            while (IsMovable && Input.GetMouseButton(0))
            {
                yield return null;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                transform.position = ray.GetPoint(40);
                Debug.DrawRay(ray.origin, ray.direction * 40, Color.red);
                if (Input.GetMouseButtonUp(0))
                {
                    IsMovable = false;
                }
            }
        }

        public void Click()
        {
            StartCoroutine(Move());
        }

        public void Select()
        {
        }

        public void UnSelect()
        {
        }
    }
}