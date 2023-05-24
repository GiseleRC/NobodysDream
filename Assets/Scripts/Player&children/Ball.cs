using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float timeWait = 5f;
    private float currTimeWait;
    void Start()
    {
        currTimeWait = 0f;
    }

    void Update()
    {
        if (transform.parent != null )
            return;
        currTimeWait += Time.deltaTime;

        if (currTimeWait >= timeWait)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Estoy colisionando con " + collision.gameObject.name);  
    }
}
