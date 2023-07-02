using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorBall : MonoBehaviour
{
    [SerializeField] private MiniBoss miniBoss;
    [SerializeField] public GameObject cartelGO, Z1GO, Z2GO;
    //private bool glassesEnableRB;
    void Update()
    {
        //if (glassesEnableRB)
        //{

        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name == "SensorGlasses" && collision.gameObject.name == "BowlinBall - primera")
        {
            Z1GO.SetActive(false);
        }
        else if (gameObject.name == "SensorGlasses" && collision.gameObject.name == "BowlinBall - segunda")
        {
            Z2GO.SetActive(false);
            cartelGO.SetActive(true);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        if (gameObject.name == "BowlinBall - primera" || gameObject.name == "BowlinBall - segunda" && collision.gameObject.name == "Compuerta tobogan")
        {
            miniBoss.gateBlueClose = true;
            miniBoss.gatePinkClose = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "SensorClose" && other.gameObject.name == "BowlinBall - primera")
        {
            miniBoss.gateGreenClose = true;
        }
        else if (gameObject.name == "SensorClose" && other.gameObject.name == "BowlinBall - segunda")
        {
            miniBoss.gateGreenClose = true;
        }
    }
}
