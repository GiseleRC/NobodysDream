using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public bool doorEnable1 = false;
    public bool doorEnable2 = false;
    public bool doorEnable3 = false;
    public bool practice1 = false;
    public bool practice2 = false;
    public bool practice3 = false;
    public DialogSystem dialogS;
    public Animator animatorWall;
    public GameObject particle1, particle2, particle3, diana1, diana2, diana3, ligthOff;
    public AudioSource audioSource, primeraDiana;
    public AudioClip openWall;
    bool playSound;

    void Update()
    {
        if (doorEnable1 && doorEnable2 && doorEnable3)
        {
            animatorWall.SetBool("EnableMove", true);
            if (!playSound)
            {
                audioSource.PlayOneShot(openWall);
                playSound = true;
            }
            dialogS.wallsB = true;
        }
        if (doorEnable1)
        {
            particle1.SetActive(true);
            diana3.SetActive(true);
        }
        if (doorEnable2)
        {
            particle2.SetActive(true);
            diana1.SetActive(true);
        }
        if (doorEnable3)
        {
            particle3.SetActive(true);
        }

        if (practice1 && practice2 && practice3)
        {
            dialogS.firstDianaB = true;
            ligthOff.SetActive(false);
            diana2.SetActive(true);
            primeraDiana.Play();
        }
    }
}
