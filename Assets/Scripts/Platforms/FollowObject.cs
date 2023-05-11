using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float speed;
    [SerializeField] GameObject checker;
    Rigidbody rb;
    bool ray;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        checker.transform.rotation = transform.rotation;
        ray = Physics.BoxCast(checker.GetComponent<Collider>().bounds.center, checker.transform.localScale, -transform.up, out hit, checker.transform.rotation, 0.5f, layerMask);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(checker.transform.position + (-transform.up * 0.5f),checker.transform.localScale) ;
    }

    private void FixedUpdate()
    {
        if (!ray)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            print("No choque");

        }
        else
        {
            print("choque");
        }
        
    }
}
