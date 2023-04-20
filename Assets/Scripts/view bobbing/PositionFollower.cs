using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollower : MonoBehaviour
{
    //Clase para seguir el objeto
    public Transform TargetTransform;
    public Vector3 Offset;

    void Update()
    {
        transform.position = TargetTransform.position + Offset; //Asigna el transform  de la clase al transform del objeto + el offset
    }
}
