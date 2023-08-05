using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockEnemy : Enemies, IEnemy
{
    MonoBehaviour patrol, explode, stayPos;
    [SerializeField] float distanceForExplode;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        Behaviors();
    }

    // Update is called once per frame
    void Update()
    {
        Variables();
        Transitions();
    }

    public void Behaviors()
    {
        patrol = GetComponent<Patrol>();
        explode = GetComponent<Explode>();
    }


    public void Variables()
    {
        distance = Vector3.Distance(characterPos.position, transform.position);
    }

    public void Transitions()
    {
        if (distance < distanceForExplode)
        {
            patrol.enabled = false;
            explode.enabled = true;
        }
        else
        {
            patrol.enabled = true;
            explode.enabled = false;
        }
    }

    public void Stunned()
    {

    }
}
