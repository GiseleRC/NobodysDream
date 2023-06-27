using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] int currentPoint;
    [SerializeField] Material whiteEyes;
    Ghost ghost;
    Thief thief;
    NavMeshAgent nma;

    void OnEnable()
    {
        if (GetComponent<Ghost>() != null)
        {
            ghost = GetComponent<Ghost>();
            nma = ghost.NMA;
        }
        else
        {
            thief = GetComponent<Thief>();
            nma = thief.NMA;
        }

        nma.ResetPath();
        nma.SetDestination(patrolPoints[currentPoint].position);
        if (whiteEyes != null)
        {
            GameObject.Find("PM3D_Sphere3D1").GetComponent<MeshRenderer>().material = whiteEyes;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
        if (GetComponent<Ghost>() != null)
        {
            ghost = GetComponent<Ghost>();
            nma = ghost.NMA;
        }
        else
        {
            thief = GetComponent<Thief>();
            nma = thief.NMA;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!nma.pathPending && nma.hasPath && nma.remainingDistance < 0.5f)
        {
            if (currentPoint < patrolPoints.Length - 1)
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
}