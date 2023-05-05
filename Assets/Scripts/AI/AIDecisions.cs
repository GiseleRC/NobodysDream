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
    GameState gameState;
    bool ghostAttack;
    
    public bool GhostAttack
    {
        set { ghostAttack = value; }
        get { return ghostAttack; }
    }

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
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
        print(ghostAttack);

        var mode = gameState.GetPlaneMode();

        characterPos = GameObject.Find("Char").GetComponent<Transform>();

        if (characterPos != null)
        {
            distance = Vector3.Distance(characterPos.position, transform.position);
            Vector3 vectorAPj = characterPos.position - transform.position;
            vectorAPj.Normalize();
            float dot = Vector3.Dot(transform.forward, vectorAPj);

            if (mode == GameState.PlaneMode.Ghost)
            {
                gameObject.GetComponent<StayPos>().enabled = true;

                if(gameObject.GetComponent<Patrol>().enabled == true)
                {
                    gameObject.GetComponent<Patrol>().enabled = false;
                }

                if(gameObject.GetComponent<ChaseCharacter>().enabled == true)
                {
                    gameObject.GetComponent<ChaseCharacter>().enabled = false;
                }
            }
            else
            {
                gameObject.GetComponent<StayPos>().enabled = false;
                if (!ghostAttack)
                {
                    if (dot > 0.55 && distance < viewDistance || distance < viewDistance / 3)
                    {
                        gameObject.GetComponent<Patrol>().enabled = false;
                        gameObject.GetComponent<ChaseCharacter>().enabled = true;
                    }
                    else if (distance > viewDistance)
                    {
                        gameObject.GetComponent<ChaseCharacter>().enabled = false;
                        gameObject.GetComponent<Patrol>().enabled = true;

                    }

                }
                else
                {
                    gameObject.GetComponent<Patrol>().enabled = false;
                    gameObject.GetComponent<ChaseCharacter>().enabled = false;
                    gameObject.GetComponent<ghAttack>().enabled = true;
                }

            }
        }
    }
}
