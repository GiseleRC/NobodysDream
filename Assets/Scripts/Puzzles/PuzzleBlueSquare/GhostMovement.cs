using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] public bool canITalk;
    //[SerializeField] private GameObject dialog;
    void Update()
    {
        if (canITalk)
        {
            //dialog.SetActive(true);
        }
    }
}
