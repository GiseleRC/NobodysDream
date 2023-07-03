using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{
    [SerializeField] GameObject button1GO, particle1GO, lightUp1GO, medio1GO;
    [SerializeField] public bool button1enable, particle1Off, lightUp1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button1enable)
        {
            button1GO.SetActive(true);
            button1enable = false;
        }
        if (particle1Off)
        {
            particle1GO.SetActive(false);
            particle1Off = false;
        }
        if (lightUp1)
        {
            lightUp1GO.SetActive(true);
            lightUp1 = false;
        }
    }
}
