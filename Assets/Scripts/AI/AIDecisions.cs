using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDecisions : MonoBehaviour
{
    Transform characterPos;
    [SerializeField] float viewDistance;
    protected NavMeshAgent nma;
    float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    public Transform CharacterPos
    {
        get
        {
            return characterPos;
        }
    }

    public float Distance
    {
        get
        {
            return distance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        characterPos = GameObject.Find("Char").GetComponent<Transform>();

        if (characterPos != null)
        {
            distance = Vector3.Distance(characterPos.position, transform.position);
            Vector3 vectorAPj = characterPos.position - transform.position;
            vectorAPj.Normalize();
            float dot = Vector3.Dot(transform.forward, vectorAPj);

            if (dot > 0.55 && distance < viewDistance || distance < viewDistance / 3)
            {
                gameObject.GetComponent<Patrol>().enabled = false;
                gameObject.GetComponent<ChaseCharacter>().enabled = true;
            }
            else if(distance > viewDistance)
            {
                gameObject.GetComponent<Patrol>().enabled = true;
                gameObject.GetComponent<ChaseCharacter>().enabled = false;
            }

        }
    }
}
