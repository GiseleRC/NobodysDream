using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SensorPlayer : MonoBehaviour
{
    [SerializeField] UnityEvent TriggerEventEnter;
    [SerializeField] UnityEvent TriggerEventExit;
    private void OnTriggerEnter(Collider other)
    {
        PlayerSC playerC = other.GetComponent<PlayerSC>();

        if (playerC != null)
        {
            TriggerEventEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerSC playerC = other.GetComponent<PlayerSC>();

        if (playerC != null)
        {
            TriggerEventExit.Invoke();
        }
    }
}
