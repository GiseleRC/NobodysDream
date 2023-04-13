using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMode : MonoBehaviour
{

    public Color[] skyColors;
    private int currentSkyColorIndex = 0;

    void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", skyColors[currentSkyColorIndex]);
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Debug.Log("Escrolee");
        if (scroll > 0f)
        {
            currentSkyColorIndex = (currentSkyColorIndex + 1) % skyColors.Length;
            RenderSettings.skybox.SetColor("_Tint", skyColors[currentSkyColorIndex]);
        }
        else if (scroll < 0f)
        {
            currentSkyColorIndex--;
            if (currentSkyColorIndex < 0)
            {
                currentSkyColorIndex = skyColors.Length - 1;
            }
            RenderSettings.skybox.SetColor("_Tint", skyColors[currentSkyColorIndex]);
        }
    }
}
