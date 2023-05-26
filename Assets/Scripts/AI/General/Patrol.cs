using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField]int currentPoint;
    [SerializeField] Material whiteEyes;
    NavMeshAgent nma;

    void OnEnable()
    {
        if(nma == null)
        {
            nma = GetComponent<NavMeshAgent>();
        }
        nma.SetDestination(patrolPoints[currentPoint].position);
        if (gameObject.tag != "Thief") 
        {
            nma.speed = 3.5f;  
        }
        if (whiteEyes != null)
        {
            GameObject.Find("PM3D_Sphere3D1").GetComponent<MeshRenderer>().material = whiteEyes;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
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

    /*public void Stunned(float stunDuration)
    {
        stunned = true;
        actualTime = stunDuration;
    }*/
}
