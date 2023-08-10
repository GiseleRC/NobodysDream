using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] public bool canITalk;
    [SerializeField] private GameObject dialog, disablesensor;
    [SerializeField] public float timeCount;

    void Update()
    {

        if (canITalk)
        {
            timeCount -= Time.deltaTime;
            canITalk = false;
        }
        if (timeCount <= 0f)
        {
            dialog.SetActive(false);
            //HACER QUE EL FANTASMA AL TERMINAR EL TIEMPO RETROCEDA HACIA ATRAS DE TABLERO
        }
    }

    public void CanTalk()
    {
        dialog.SetActive(true);
        canITalk = true;
        disablesensor.SetActive(false);
    }
}
