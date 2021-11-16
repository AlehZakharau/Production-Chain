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
                var position = Input.mousePosition;
                position.z = 40;
                position = Camera.main.ScreenToWorldPoint(position);
                transform.position = position;
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
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == 7 && IsMovable)
            {
                other.gameObject.GetComponent<ICollisionally>().Execute();
                IsMovable = false;
            }
            
        }

        private void ConnectPointToManufacture()
        {
            IsMovable = false;
        }
    }
}