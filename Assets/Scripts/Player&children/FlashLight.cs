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
    bool hasFlashlight = true;//cuando agarre la flashlight hay que ponerlo en false despues
    bool canUseFlashlight = true;//pregunte si puede usar la linterna en el plano

    public bool FlashLightEnabled
    {
        get
        {
            return flashLight.enabled;
        }
    }

    public bool Flicker(bool flickerState)
    {
        return flicker = flickerState;
    }

    void Start()
    {
        flashLight = GetComponent<Light>();
        Timer = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = canUseFlashlight;

        if (!canUseFlashlight)
        {
            flashLight.enabled = false;
        }
        else if (Input.GetButtonDown("Flashlight"))
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

    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        canUseFlashlight = planeMode == GameState.PlaneMode.Dream;
    }
}
