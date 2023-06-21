using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.localPosition;
    }

    public void ResetPosition()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localPosition = initialPos;
    }
}
