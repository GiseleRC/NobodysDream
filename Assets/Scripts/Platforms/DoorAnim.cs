using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public Animator animatorDoor;

    public void EventAnimOpenDoor()
    {
        animatorDoor.Play("Open");
    }

    public void EventAnimCloseDoor()
    {
        animatorDoor.Play("Close");
    }
}
