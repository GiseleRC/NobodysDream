using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCloth : MonoBehaviour
{
 
    public float alturaMaxima; // altura máxima a la que levitará la cápsula
    public float velocidadLevitacion; // velocidad de levitación de la cápsula

    private Vector3 posicionInicial;
    public bool collitionE = false;

    void Start()
    {
        posicionInicial = transform.position;
    } 

    void Update()
    {
        transform.position = posicionInicial + new Vector3(0, Mathf.Sin(Time.time * velocidadLevitacion) * alturaMaxima, 0);

        if (collitionE)
        {
            Debug.Log("Colisione");
            gameObject.SetActive(false);
        }
    }

}
