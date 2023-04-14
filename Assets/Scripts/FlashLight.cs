using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light flashLight;
    public AudioSource flashLightOn, flashLightOff;

    public float MinTime;
    public float MaxTime;
    public float Timer;
    public float posibility;
    bool flicker;
   // Start is called before the first frame update

    public bool Flicker(bool flickerState)
    {
        return flicker = flickerState;
    }

    void Start()
    {
        flashLight = GetComponent<Light>();
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            if (flashLight.enabled)
            {
                flashLight.enabled = false;
                flashLightOff.Play();
            }
            else
            {
                flashLight.enabled = true;
                flashLightOn.Play();
            }
        }

        posibility = Random.Range(0f, 1f);

        if (flicker)
        {
            FlickerLight();
        }
    }
    void FlickerLight()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if (posibility <= 0.01)
        {
             if (Timer <= 0)
             {
                  flashLight.enabled = !flashLight.enabled;
                  Timer = Random.Range(MinTime, MaxTime);
             }
        }
    }  
}
