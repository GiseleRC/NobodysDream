using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Explode : MonoBehaviour
{
    [SerializeField] float radiusExplosion, amountTimer, timerForExplode, shakeDuration, shakePotential;
    float actualTime;
    [SerializeField] ClockEnemy clockEnemy;
    [SerializeField] NavMeshAgent nma;
    

    // Start is called before the first frame update

    void Start()
    {
        clockEnemy = GetComponent<ClockEnemy>();
        nma = clockEnemy.NMA;
        nma.SetDestination(transform.position);
        actualTime = timerForExplode;
    }

    void OnEnable()
    {
        clockEnemy = GetComponent<ClockEnemy>();
        nma = clockEnemy.NMA;
        nma.SetDestination(transform.position);
        actualTime = timerForExplode;
    }

    // Update is called once per frame
    void Update()
    {
        actualTime -= Time.deltaTime;

        if(actualTime <= 0)
        {
            print("explote");
            Explosion();
        }
    }

    void Explosion()
    {
        var explosionArea = Physics.OverlapSphere(transform.position, radiusExplosion);

        foreach (Collider character in explosionArea)
        {
            if(character.gameObject.name == "Char")
            {
                GameObject.Find("TimerController").GetComponent<TimerController>().SubstractTime(amountTimer);
                GameObject.Find("CameraHolder").GetComponent<Shaking>().ShakeExplosion(shakeDuration);
            }
            
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusExplosion);
    }
}
