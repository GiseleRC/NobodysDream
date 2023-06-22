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

    //private void Update()
    //{
    //    if (piece1Bool && piece2Bool && piece3Bool && piece4Bool && piece5Bool && piece6Bool)
    //    {

    //    }
    //}
}
