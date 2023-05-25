using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThierfEnemyDecisions : MonoBehaviour
{
    Transform characterPos, objectPos;
    [SerializeField] float viewDistance;
    protected NavMeshAgent nma;
    float distance;
    GameState gameState;
    bool enemyStunned, objectToSteal;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public bool EnemyStunned
    {
        set { enemyStunned = value; }
    }

    public Transform CharacterPos
    {
        get
        {
            return characterPos;
        }
    }    
    
    public Transform ObjectPos
    {
        get
        {
            return objectPos;
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

        var mode = gameState.GetPlaneMode();

        characterPos = GameObject.Find("Char").GetComponent<Transform>();

        if (characterPos != null)
        {
            distance = Vector3.Distance(characterPos.position, transform.position);

            if (mode == GameState.PlaneMode.Ghost)
            {
                gameObject.GetComponent<StayPos>().enabled = true;

                if (gameObject.GetComponent<Patrol>().enabled == true)
                {
                    gameObject.GetComponent<Patrol>().enabled = false;
                }
            }
            else
            {
                gameObject.GetComponent<StayPos>().enabled = false;
                if (!enemyStunned)
                {
                    if (objectToSteal)
                    {
                        GetComponent<MoveToMatObject>().enabled = true;
                        GetComponent<Patrol>().enabled = false;

                    }
                    else
                    {
                        GetComponent<Patrol>().enabled = true;
                        GetComponent<MoveToMatObject>().enabled = false;
                    }
                }

                if (enemyStunned)
                {
                    GetComponent<Stunned>().enabled = true;
                    GetComponent<Patrol>().enabled = false;
                    GetComponent<MoveToMatObject>().enabled = false;
                }
            }
        }
    }

    public void CheckPosObject(Transform pos)
    {
        print("ejecute");
        NavMeshPath navMeshStatus = new NavMeshPath();
        nma.CalculatePath(pos.position, navMeshStatus);

        if (navMeshStatus.status == NavMeshPathStatus.PathComplete)
        {
            objectToSteal = true;
            objectPos = pos;
        }
    }
}
