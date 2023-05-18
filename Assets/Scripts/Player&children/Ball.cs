using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float timeWait = 10f;
    [SerializeField] private float currTimeWait;
    void Start()
    {
        currTimeWait = timeWait;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
