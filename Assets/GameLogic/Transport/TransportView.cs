using System;
using UnityEngine;

namespace GameLogic.Transport
{
    public interface ITransportView
    {
        public event Action onClick;
        public event Action OnDestroy;
        public Vector3 SenderPosition { get; set; }
        
        public Vector3 ReceiverPosition { get; set; }
    }
    public class TransportView : MonoBehaviour, ITransportView, IClickable
    {
        //[SerializeField] private TransportPoint senderPoint;
        //[SerializeField] private TransportPoint receiverPoint;
        [SerializeField] private GameObject connection;
        public event Action onClick;
        public event Action OnDestroy;

        private Vector3 senderPosition;
        private Vector3 receiverPosition;
        public Vector3 SenderPosition { get; set; }

        public Vector3 ReceiverPosition
        {
            get => receiverPosition;
            set
            {
                receiverPosition = value;
                SetConnection();
            }
        }

        private Material baseMaterial;

        private Color baseColor;

        private bool isSelected;

        private void Awake()
        {
            baseMaterial = connection.GetComponent<MeshRenderer>().material;
            baseColor = baseMaterial.color;
        }


        private void SetConnection()
        {
            var target = ReceiverPosition - SenderPosition;
            connection.transform.position = SenderPosition + 0.5f * (target);
            //target.Normalize();
            //var targetAngle = Mathf.Atan2(ReceiverPosition.y, ReceiverPosition.x) * Mathf.Rad2Deg;
            //connection.transform.Rotate(Vector3.forward, targetAngle);
            connection.transform.LookAt(ReceiverPosition);
            var distance = Vector3.Distance(SenderPosition, ReceiverPosition);
            connection.transform.localScale = new Vector3(0.3f, 0.3f, distance);
        }

        private void Update()
        {
            // if (receiverPoint.IsMovable || senderPoint.IsMovable)
            // {
            //     SetConnection();
            // }
            if (Input.GetMouseButtonDown(1) && isSelected)
            {
                OnDestroy?.Invoke();
                Destroy(gameObject);
                //Delete Model, Controller and fabrics
                // or GC destroy it by itself
            }
        }

        private void ShowSelected()
        {
            baseMaterial.color = Color.yellow;
        }

        public void Click()
        {
            onClick?.Invoke();
        }

        public void Select()
        {
            isSelected = true;
            baseMaterial.color = Color.yellow;
        }

        public void UnSelect()
        {
            isSelected = false;
            baseMaterial.color = baseColor;
        }
        
        // public Vector3 SenderPosition { get => senderPoint.transform.position;
        //     set
        //     {
        //         if(senderPoint.transform.position == value) return;
        //         senderPoint.transform.position = value + new Vector3(0, 3, 0);
        //     }
        // }
        // public Vector3 ReceiverPosition { get => receiverPoint.transform.position;
        //     set
        //     {
        //         if(receiverPoint.transform.position == value) return;
        //         receiverPoint.transform.position = value  + new Vector3(0, -3, 0);
        //     }
        // }
    }
}