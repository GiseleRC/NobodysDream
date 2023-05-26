using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stunned : MonoBehaviour
{
    float actualTime;
    NavMeshAgent nma;
    [SerializeField] GameObject rulerGrabbed, cubeGrabbed;

    // Start is called before the first frame update

    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        if(gameObject.tag != "Thief")
        {
            GetComponent<AIDecisions>().EnemyStunned = true;
            GetComponent<AIDecisions>().GhostAttack = false;
        }
        else
        {
            GetComponent<ThierfEnemyDecisions>().EnemyStunned = true;
            rulerGrabbed.SetActive(false);
            cubeGrabbed.SetActive(false);

        }
    }

    void OnDisable()
    {
        if(gameObject.tag != "Thief")
        {
            GetComponent<AIDecisions>().EnemyStunned = false;
        }
        else
        {
            GetComponent<ThierfEnemyDecisions>().EnemyStunned = false;
        }
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
