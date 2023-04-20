using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform platform; 
    public Transform pos1;
    public Transform pos2;

    Vector3 pos;
    int index = 0;
    float distMin = 0.5f;

    private void Update()
    {
        if (gameObject.name == "PlatMovil1")
        {
            MovePlatform();
        } 
    }
    void MovePlatform()
    {
        if (index == 0)
        {
            Vector3 dir = pos2.position - platform.transform.position;
            platform.transform.position = platform.transform.position + dir * Time.deltaTime;

            if (Vector3.Distance(platform.position, pos2.position) < distMin)
            {
                index = 1;
                Debug.Log("El index es " + index);
            }
        }
        else
        {
            Vector3 dir = pos1.position - platform.transform.position;
            platform.transform.position = platform.transform.position + dir * Time.deltaTime;

            if (Vector3.Distance(platform.position, pos1.position) < distMin)
            {
                index = 0;
                Debug.Log("El index es " + index);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MatObject")) && collision.gameObject.name != gameObject.name)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MatObject")) && collision.gameObject.name != gameObject.name)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
