using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMode : MonoBehaviour
{

    public Color colorChanghed = Color.red; // color al que cambia el entorno
    public float duration = 2f; // duración del cambio de color
    public float timeWait = 0f; // tiempo de espera antes del cambio de color

    private Color colorOriginal;
    private float initialTimeChang = 0f;
    private bool colorTrigger = false;

    void Start()
    {
        colorOriginal = RenderSettings.ambientSkyColor;
    }

    void Update()
    {
        if (colorTrigger)
        {
            float tiempoCambio = Time.time - initialTimeChang;
            if (tiempoCambio >= duration)
            {
                colorTrigger = false;
                RenderSettings.ambientSkyColor = colorOriginal;
            }
            else
            {
                RenderSettings.ambientSkyColor = Color.Lerp(colorOriginal, colorChanghed, tiempoCambio / duration);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("ChangeColorNow", timeWait);
        }
    }

    void ChangeColorNow()
    {
        colorTrigger = true;
        initialTimeChang = Time.time;
    }

    /*     public Color skyColor;

    void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", skyColor);
    }
} */

}
