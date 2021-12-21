using System;
using GameLogic.CameraController;
using GameLogic.Transport;
using UnityEngine;

public class TransportTest : MonoBehaviour
{
    [SerializeField] private Transform senderPoint;
    [SerializeField] private Transform receiverPoint;
    [SerializeField] private GameObject connection;

    private Vector3 senderPosition;
    private Vector3 receiverPosition;
    public Vector3 SenderPosition { get; set; }

    public Vector3 ReceiverPosition
    {
        get => receiverPosition;
        set => receiverPosition = value;
    }

    private void Start()
    {
        SenderPosition = senderPoint.position;
        ReceiverPosition = receiverPoint.position;
        SetConnection();
    }


    private void SetConnection()
    {
        var target = ReceiverPosition - SenderPosition;
        connection.transform.position = SenderPosition + 0.5f * (target);
        //target.Normalize();
        var y = Mathf.Abs(ReceiverPosition.y - SenderPosition.y);
        var x = Mathf.Abs(ReceiverPosition.x - SenderPosition.x);
        Debug.Log($"X: {x}, Y: {y}");
        var targetAngle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + 90;
        Debug.Log($"target angle {targetAngle}");
        connection.transform.Rotate(Vector3.forward, targetAngle);
        //connection.transform.LookAt(ReceiverPosition);
        var distance = Vector3.Distance(SenderPosition, ReceiverPosition);
        connection.transform.localScale = new Vector3(0.3f, distance, 0.3f);
    }

    private void Update()
    {
        // if (receiverPoint.IsMovable || senderPoint.IsMovable)
        // {
        //     SetConnection();
        // }
        // if (Input.GetMouseButtonDown(1) && isSelected)
        // {
        //     OnDestroy?.Invoke();
        //     //Delete Model, Controller and fabrics
        //     // or GC destroy it by itself
        // }
    }
}