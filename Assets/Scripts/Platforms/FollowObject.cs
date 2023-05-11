using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame

    /*public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.velocity = new Vector3(0, 5f * Time.deltaTime, 0);
            rb.isKinematic = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.isKinematic = true;
        }
    }*/
}
