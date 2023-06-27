using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Char")
        {
            other.GetComponent<PlayerSC>().TrampolineJump();
            GetComponent<AudioSource>().Play();
        }
    }
}
