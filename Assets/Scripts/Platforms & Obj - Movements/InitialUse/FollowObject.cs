using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float speed, rayDistance;
    [SerializeField] GameObject checker, parent;
    bool ray, dontMove;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        //print(dontMove);
        ray = Physics.BoxCast(checker.transform.position, checker.transform.localScale/2, -transform.up, out hit, transform.rotation, rayDistance, layerMask);

        if (!ray)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            parent.GetComponent<BoxCollider>().isTrigger = true;

        }
        else if(ray && hit.collider == parent)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else
        {
            parent.GetComponent<BoxCollider>().isTrigger = false;

            var thiefs = FindObjectsOfType<ThierfEnemyDecisions>();

            foreach (var thief in thiefs)
            {
                thief.CheckPosObject(transform);
            }

            if (parent != null)
            {
                parent.layer = 6;
            }
            else
            {
                gameObject.layer = 6;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * rayDistance);
    }

}
