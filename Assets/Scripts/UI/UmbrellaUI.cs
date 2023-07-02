using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UmbrellaUI : MonoBehaviour
{
    Slider slider;
    Umbrella umbrella;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        umbrella = GameObject.Find("Char").GetComponentInChildren<Umbrella>();
        slider.maxValue = umbrella.MaxTimeUmbrella;

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, umbrella.ActualTime, 0.02f);
    }
}
