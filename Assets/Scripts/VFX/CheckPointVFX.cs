using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointVFX : MonoBehaviour
{
    [SerializeField] GameObject torch;
    private void OnTriggerEnter(Collider other)
    {
       torch.GetComponent<EnableFireTorch>().PlayFire();
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
