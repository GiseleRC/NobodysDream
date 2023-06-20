using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    private Vector3 initialPos;
    private Quaternion initialRot;

    private void Awake()
    {
        initialPos = transform.localPosition;
        initialRot = transform.localRotation;
    }

    public void ResetTransform()
    {
        transform.localPosition = initialPos;
        transform.localRotation = initialRot;
    }
}
