using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    FlashLight fl;
    bool flashlightOn;
    [SerializeField] float stunDuration;
    // Start is called before the first frame update

    void Update()
    {
        fl = GetComponentInParent<FlashLight>();
        flashlightOn = fl.FlashLightEnabled;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 11 && flashlightOn == true)
        {
            if (other.gameObject.GetComponent<Patrol>().enabled) other.gameObject.GetComponent<Patrol>().Stunned(stunDuration);
            if (other.gameObject.GetComponent<ChaseCharacter>().enabled) other.gameObject.GetComponent<ChaseCharacter>().Stunned(stunDuration);
        }
    }
}