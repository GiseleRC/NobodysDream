using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public Animator animatorDoor;
    public AudioSource DoorSound;

    public void EventAnimOpenDoor()
    {
        animatorDoor.Play("Open");
        DoorSound.Play();
    }

    public void EventAnimCloseDoor()
    {
        animatorDoor.Play("Close");
        DoorSound.Play();
    }
}
