using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    [SerializeField] public bool gateGreenOpen, gateBlueOpen, gatePinkOpen, gateGreenClose, gateBlueClose, gatePinkClose;
    [SerializeField] private Animator gateGreenA, gateBlueA, gatePinkA;
    [SerializeField] private AudioSource openSound, closeSound;

    void Update()
    {
        if (gateGreenOpen)
        {
            EventAnimOpenGreen();
            gateGreenOpen = false;
        }
        else if (gateGreenClose)
        {
            EventAnimCloseGreen();
            gateGreenClose = false;
        }

        if (gateBlueOpen)
        {
            EventAnimOpenBlue();
            gateBlueOpen = false;
        }
        else if (gateBlueClose)
        {
            EventAnimCloseBlue();
            gateBlueClose = false;
        }

        if (gatePinkOpen)
        {
            EventAnimOpenPink();
            gatePinkOpen = false;
        }
        else if (gatePinkClose)
        {
            EventAnimClosePink();
            gatePinkClose = false;
        }
    }

    public void EventAnimOpenGreen()
    {
        gateGreenA.Play("openGreen");
        openSound.Play();
    }
    public void EventAnimCloseGreen()
    {
        gateGreenA.Play("closeGreen");
        closeSound.Play();
    }

    public void EventAnimOpenBlue()
    {
        gateGreenA.Play("openBlue");
        openSound.Play();
    }
    public void EventAnimCloseBlue()
    {
        gateGreenA.Play("closeBlue");
        closeSound.Play();
    }

    public void EventAnimOpenPink()
    {
        gateGreenA.Play("openPink");
        openSound.Play();
    }
    public void EventAnimClosePink()
    {
        gateGreenA.Play("closePink");
        closeSound.Play();
    }
}
