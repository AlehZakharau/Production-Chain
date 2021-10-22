using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestInstantiate : MonoBehaviour
    {
        public GameObject bridge;
        public Transform senderPosition;
        public Transform receiverPosition;
        public Vector3 SenderPosition { get; set; }
        public Vector3 ReceiverPosition { get; set; }


        private void Awake()
        {
            SenderPosition = senderPosition.position;
            ReceiverPosition = receiverPosition.position;
            CreateBridge();
        }

        private GameObject instance;
        public void CreateBridge()
        {
            instance = Instantiate(bridge);
            instance.transform.position = SenderPosition + 0.5f * (ReceiverPosition - SenderPosition);
            var angle = Vector3.Angle(instance.transform.position, ReceiverPosition);
            //instance.transform.LookAt(ReceiverPosition);
            var target = ReceiverPosition - SenderPosition;
            target.Normalize();
            var targetAngle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90;
            instance.transform.Rotate(Vector3.forward, targetAngle);
            var distance = Vector3.Distance(SenderPosition, ReceiverPosition);
            instance.transform.localScale = new Vector3(1, distance,1 );
        }
    }
}