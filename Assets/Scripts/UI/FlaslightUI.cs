using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlaslightUI : MonoBehaviour
{
    Slider slider;
    FlashLight flashlight;
    [SerializeField] GameObject disable;
    bool disableBool;
    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.Find("Char").GetComponentInChildren<FlashLight>();
        slider = GetComponent<Slider>();
        slider.maxValue = flashlight.MaxBattery;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = flashlight.ActualBattery;

        if (flashlight.BatteryDead || disableBool == false)
        {
            disable.SetActive(true);
        }
        else
        {
            disable.SetActive(false);
        }
    }

    public void OnPlaneModeChanged(GameState.PlaneMode planeMode)
    {
        disableBool = planeMode == GameState.PlaneMode.Dream;
    }
}
