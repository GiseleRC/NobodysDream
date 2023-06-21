using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    private Vector3 initialPos;
    private GameObject piece1Bool, piece2Bool, piece3Bool, piece4Bool, piece5Bool, piece6Bool;

    private void Start()
    {
        initialPos = transform.localPosition;
    }

    public void ResetPosition()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localPosition = initialPos;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == "Peon 7-4" && other.name == "Casillero  7-2")
        {
            piece1Bool.SetActive(true);
        }
        else if (gameObject.name == "Caballo 8-3" && other.name == "Casillero  7-1")
        {
            piece2Bool.SetActive(true);
        }
        else if (gameObject.name == "Alfil 4-3" && other.name == "Casillero  6-1")
        {
            piece3Bool.SetActive(true);
        }
        else if (gameObject.name == "Peon 5-3" && other.name == "Casillero  5-2")
        {
            piece4Bool.SetActive(true);
        }
        else if (gameObject.name == "Peon 2-3" && other.name == "Casillero 1-2")
        {
            piece5Bool.SetActive(true);
        }
        else if (gameObject.name == "Torre 1-4" && other.name == "Casillero  1-1")
        {
            piece6Bool.SetActive(true);
        }
    }

    private void Update()
    {
        if (piece1Bool && piece2Bool && piece3Bool && piece4Bool && piece5Bool && piece6Bool)
        {

        }
    }
}
