using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stunned : MonoBehaviour
{
    float actualTime;
    NavMeshAgent nma;

    // Start is called before the first frame update

    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        GetComponent<AIDecisions>().EnemyStunned = true;
        GetComponent<AIDecisions>().GhostAttack = false;
    }

    void OnDisable()
    {
        GetComponent<AIDecisions>().EnemyStunned = false;
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(transform.position);
        actualTime -= Time.deltaTime;

        if(actualTime <= 0)
        {
            this.enabled = false;
        }
    }

    public void StunEnemy(float stunDuration)
    {
        actualTime = stunDuration;
    }
}
