using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float timeWait = 0f;
    [SerializeField] private float currTimeWait;
    void Start()
    {
        currTimeWait = timeWait;
    }

    void Update()
    {
        currTimeWait += Time.deltaTime;
        if (currTimeWait >= 10)
        {
            Destroy(this);
        }
    }
}
