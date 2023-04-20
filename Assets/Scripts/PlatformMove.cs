using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform Platform; 
    public Transform pos1;
    public Transform pos2;

    Vector3 pos;
    int index = 0;
    float distMin = 0.5f;

    private void Update()
    {
        if (index == 0)
        {
            Vector3 dir = pos2.position - Platform.transform.position;
            Platform.transform.position = Platform.transform.position + dir * Time.deltaTime;

            if (Vector3.Distance(Platform.position, pos2.position) < distMin)
            {
                index = 1;
                Debug.Log("El index es " + index);
            }
        }
        else
        {
            Vector3 dir = pos1.position - Platform.transform.position;
            Platform.transform.position = Platform.transform.position + dir * Time.deltaTime;

            if (Vector3.Distance(Platform.position, pos1.position) < distMin)
            {
                index = 0;
                Debug.Log("El index es " + index);
            }
        }
    }
}
