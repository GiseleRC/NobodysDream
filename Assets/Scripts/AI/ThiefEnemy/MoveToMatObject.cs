using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToMatObject : MonoBehaviour
{
    NavMeshAgent nma;
    Transform objectPos;
    // Start is called before the first frame update
    private void OnEnable()
    {
        objectPos = GetComponent<ThierfEnemyDecisions>().ObjectPos;
    }

    private void OnDisable()
    {
        GetComponent<ThierfEnemyDecisions>().StealObject = false;
        
    }

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectPos != null)
        {
            float distance = Vector3.Distance(transform.position, objectPos.position);

            if(distance < 1)
            {
                nma.SetDestination(transform.position);
                GetComponent<ThierfEnemyDecisions>().StealObject = true;
            }
            else
            {
                GetComponent<ThierfEnemyDecisions>().StealObject = false;
                nma.SetDestination(objectPos.position);
            }
        }
        else
        {
            GetComponent<ThierfEnemyDecisions>().ObjectToSteal = false;
            this.enabled = false;
        }

    }
}
