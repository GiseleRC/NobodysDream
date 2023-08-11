using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject pointA, pointB, paraguas;
    Vector3 initialPointA;
    public bool grabbed;
    public float timeTraveler;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        initialPointA = pointA.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(pointA.transform.position, pointB.transform.position);

        if(grabbed == true)
        {
            GameObject.Find("Char").transform.parent = pointA.transform;
            GameObject.Find("Char").GetComponent<Rigidbody>().isKinematic = true;
            pointA.transform.position = Vector3.SmoothDamp(pointA.transform.position, pointB.transform.position, ref velocity, timeTraveler * Time.deltaTime);
        }
        else
        {
            pointA.transform.position = Vector3.SmoothDamp(pointA.transform.position, initialPointA, ref velocity, timeTraveler * Time.deltaTime);

        }

        if (Input.GetButtonDown("Jump") || distance < 0.5f)
        {
            GameObject.Find("Char").GetComponent<Rigidbody>().isKinematic = false;
            grabbed = false;
            GameObject.Find("Char").transform.parent = null;
            paraguas.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Char")
        {
            if (Input.GetButton("Interact"))
            {
                paraguas.SetActive(true);
                grabbed = true;

            }
        }
    }
}
