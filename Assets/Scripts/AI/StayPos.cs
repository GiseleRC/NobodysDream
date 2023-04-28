using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StayPos : MonoBehaviour
{
    NavMeshAgent nma;
    // Start is called before the first frame update
    private void OnEnable()
    {
        
    }

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(transform.position);
    }
}
