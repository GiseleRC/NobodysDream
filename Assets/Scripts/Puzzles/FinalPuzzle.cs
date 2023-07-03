using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{
    [SerializeField] GameObject button1GO, particle1GO, lightUp1GO, lightRot1GO, medio1GO, esqueme2GO, 
                                button2GO, particle2GO, lightUp2GO, lightRot2GO, medio2GO, esqueme3GO,
                                button3GO, particle3GO, lightUp3GO, lightRot3GO, medio3GO, balloonEsqueme;
    [SerializeField] public bool button1enable, particle1Off, lightUp1, triger, backMonster1,
                                 button2enable, particle2Off, lightUp2, triger1, backMonster2,
                                 button3enable, particle3Off, lightUp3, triger2, backMonster3;

    [SerializeField] public AudioSource audioSource;

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
            //audioSource.Play();
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
        if (backMonster1)
        {
            //metodo de backea el monstruo
            //audioSource.Play();
            backMonster1 = false;
        }

        //esquema 2
        if (button2enable)
        {
            button2GO.SetActive(true);
            button2enable = false;
        }
        if (particle2Off)
        {
            particle2GO.SetActive(false);//apaga
            particle2Off = false;


            //metodo de aparece el monstruo
            //audioSource.Play();
        }
        if (lightUp2)
        {
            lightUp2GO.SetActive(true);//APARECE EL MONSTRUO Y GRITA
            lightUp2 = false;
        }
        if (triger1)
        {
            lightUp2GO.SetActive(false);
            lightRot2GO.SetActive(true);
            esqueme3GO.SetActive(true);
            medio2GO.SetActive(true);

            triger1 = false;
        }
        if (backMonster2)
        {
            //metodo de backea el monstruo
            //audioSource.Play();
            backMonster2 = false;
        }

        //esquema 3
        if (button3enable)
        {
            button3GO.SetActive(true);
            button3enable = false;
        }
        if (particle3Off)
        {
            particle3GO.SetActive(false);//apaga
            particle3Off = false;


            //metodo de aparece el monstruo
            //audioSource.Play();
        }
        if (lightUp3)
        {
            lightUp3GO.SetActive(true);//APARECE EL MONSTRUO Y GRITA
            lightUp3 = false;
        }
        if (triger2)
        {
            lightUp3GO.SetActive(false);
            lightRot3GO.SetActive(true);
            balloonEsqueme.SetActive(true);
            medio3GO.SetActive(true);

            triger2 = false;
        }
    }
}
