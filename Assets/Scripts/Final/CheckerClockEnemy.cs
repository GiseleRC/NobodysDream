using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerClockEnemy : MonoBehaviour
{
    [SerializeField] GameObject clockEnemy, actualClockEnemy;
    [SerializeField] Transform initialPos;
    [SerializeField] Transform[] patrols;
    float timer;
    [SerializeField] float timeForRespawn;
    // Start is called before the first frame update
    void Awake()
    {
        timer = timeForRespawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(actualClockEnemy == null)
        {
            timer -= Time.deltaTime;

            if(timer < 0)
            {
                actualClockEnemy = Instantiate(clockEnemy, initialPos.position, initialPos.rotation);
                clockEnemy.GetComponent<Patrol>().patrolPoints = patrols;
                timer = timeForRespawn;
            }
        }
    }
}
