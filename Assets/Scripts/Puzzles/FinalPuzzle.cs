using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{
    [SerializeField] GameObject button1GO, particle1GO, lightUp1GO, lightRot1GO, medio1GO, esqueme2GO;
    [SerializeField] public bool button1enable, particle1Off, lightUp1, triger, backMonster;

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Animator animationIdle;

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
            particle1GO.SetActive(false);//apaga
            particle1Off = false;
            

            //metodo de aparece el monstruo
            animationIdle.Play("MovementFoward");
            audioSource.Play();
        }
        if (lightUp1)
        {
            lightUp1GO.SetActive(true);//APARECE EL MONSTRUO Y GRITA
            lightUp1 = false;
        }
        if (triger)
        {
            lightUp1GO.SetActive(false);
            lightRot1GO.SetActive(true);
            esqueme2GO.SetActive(true);
            medio1GO.SetActive(true);

            triger = false;
        }
        if (backMonster)
        {
            //metodo de backea el monstruo
            animationIdle.Play("MovementBack");
            audioSource.Play();
        }
    }
}
