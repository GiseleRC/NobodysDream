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

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(objectPos.position);
    }
}
