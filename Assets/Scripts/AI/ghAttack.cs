using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghAttack : MonoBehaviour
{
    [SerializeField] float initialTimer, maxDistanceForAttack;
    float distance, timer;
    // Start is called before the first frame update

    void OnEnable()
    {
        timer = initialTimer;
        distance = gameObject.GetComponent<AIDecisions>().Distance;
        GameObject.Find("TimerController").GetComponent<TimerController>().EnemiesAttacking = 1;
    }
    void OnDisable()
    {
        GameObject.Find("TimerController").GetComponent<TimerController>().EnemiesAttacking = -1;
        gameObject.GetComponent<AIDecisions>().GhostAttack = false;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("Char").transform.position);

        if (distance > maxDistanceForAttack) 
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            GetComponent<ghAttack>().enabled = false;
        }
    }
}
