using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    private Vector3 initialPos;
    private Quaternion initialRot;

    private void Awake()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    public void ResetTransform()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().MovePosition(initialPos);
        gameObject.GetComponent<Rigidbody>().MoveRotation(initialRot);
    }
}
