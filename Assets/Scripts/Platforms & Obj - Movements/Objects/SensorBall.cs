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

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "BowlinBall - primera" || gameObject.name == "BowlinBall - segunda" && other.gameObject.name == "Sensor - closeBlue&Pink")
        {
            miniBoss.gateBlueClose = true;
            miniBoss.gatePinkClose = true;
        }

        if (gameObject.name == "SensorClose" && other.gameObject.name == "BowlinBall - primera")
        {
            miniBoss.gateGreenClose = true;
        }
        else if (gameObject.name == "SensorClose" && other.gameObject.name == "BowlinBall - segunda")
        {
            miniBoss.gateGreenClose = true;
        }

        if (gameObject.name == "SensorGlasses" && other.gameObject.name == "BowlinBall - primera")
        {
            Z1GO.SetActive(false);
        }
        else if (gameObject.name == "SensorGlasses" && other.gameObject.name == "BowlinBall - segunda")
        {
            Z2GO.SetActive(false);
            cartelGO.SetActive(true);
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
