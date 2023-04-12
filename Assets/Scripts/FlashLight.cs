using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light flashLight;

    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            if (flashLight.enabled == true)
            {
                flashLight.enabled = false;
            }
            else
            {
                flashLight.enabled = true;
            }
        }
    }
}
