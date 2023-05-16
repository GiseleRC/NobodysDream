using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float speed, rayDistance;
    [SerializeField] GameObject checker;
    bool ray;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if(checker != null)
        {
            checker.transform.rotation = transform.rotation;
        }

        if(checker != null)
        {
            ray = Physics.BoxCast(checker.GetComponent<Collider>().bounds.center, checker.transform.localScale, -transform.up, out hit, checker.transform.rotation, rayDistance, layerMask);
        }
        else
        {
            ray = Physics.BoxCast(GetComponent<Collider>().bounds.center, transform.localScale, -transform.up, out hit, transform.rotation, rayDistance, layerMask);
        }
            
        if (!ray)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);

        }
    }

    void OnDrawGizmos()
    {
        if(checker != null)
        {
            Gizmos.DrawRay(checker.transform.position,-transform.up * rayDistance);
        }
        else
        {
            Gizmos.DrawRay(transform.position, -transform.up * rayDistance);
        }
    }
}
