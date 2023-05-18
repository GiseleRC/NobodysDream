using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghAttack : MonoBehaviour
{
    [SerializeField] float initialTimer, maxDistanceForAttack;
    float distance;
    public float timer;
    public AudioSource GhostAttack, ClockSlow, ClockFast;
    // Start is called before the first frame update

    void OnEnable()
    {
        timer = initialTimer;
        GameObject.Find("TimerController").GetComponent<TimerController>().EnemiesAttacking = 1;
        GhostAttack.Play();
        ClockSlow.Stop();
        ClockFast.Play();
    }
    void OnDisable()
    {
        GameObject.Find("TimerController").GetComponent<TimerController>().EnemiesAttacking = -1;
        gameObject.GetComponent<AIDecisions>().GhostAttack = false;
        GhostAttack.Stop();
        ClockSlow.Play();
        ClockFast.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(GameObject.Find("Char").GetComponent<Transform>().position.x,transform.position.y , GameObject.Find("Char").GetComponent<Transform>().position.z));
        distance = GetComponent<AIDecisions>().Distance;

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
