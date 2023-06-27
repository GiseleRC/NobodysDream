using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] float speed, timer;
    float actualTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;

        if(actualTime > timer)
        {
            speed *= -1f;
            actualTime = 0;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}