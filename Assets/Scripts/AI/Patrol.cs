using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField]int currentPoint;
    [SerializeField] Material whiteEyes;
    bool stunned;
    float actualTime;
    NavMeshAgent nma;

    private void OnEnable()
    {
        actualTime = 0.1f;
        if (whiteEyes != null)
        {
            GameObject.Find("PM3D_Sphere3D1").GetComponent<MeshRenderer>().material = whiteEyes;

        }
        nma.SetDestination(patrolPoints[currentPoint].position);
    }
    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        nma.SetDestination(patrolPoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        {
            if(!nma.pathPending && nma.hasPath && nma.remainingDistance < 0.5f)
            {
                if(currentPoint < patrolPoints.Length - 1)
                {
                    currentPoint++;
                    nma.SetDestination(patrolPoints[currentPoint].position);
                }
                else
                {
                    currentPoint = 0;
                    nma.SetDestination(patrolPoints[0].position);
                }
            }

        }
        else
        {
            nma.SetDestination(transform.position);
            actualTime -= Time.deltaTime;

            if (actualTime <= 0)
            {
                stunned = false;
            }
        }
    }

    /*public void Stunned(float stunDuration)
    {
        stunned = true;
        actualTime = stunDuration;
    }*/
}
