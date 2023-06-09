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
    bool enemyStunned, objectToSteal, stealObject, objectGrabbed;
    [SerializeField] AudioClip laugh;
    AudioSource audioSource;

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public bool ObjectToSteal
    {
        set
        {
            objectToSteal = value;
        }
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
    
    public bool StealObject
    {
        get
        {
            return stealObject;
        }

        set
        {
            stealObject = value;
        }
    }    
    
    public bool ObjectGrabbed
    {
        get
        {
            return objectGrabbed;
        }

        set
        {
            objectGrabbed = value;
        }
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        if (nma != null)
        {
            if (nma.isStopped)
            {
                nma.isStopped = false;
            }
        }
    }

    private void OnDisable()
    {
        nma.isStopped = true;
        GetComponent<StoleItem>().enabled = false;
        GetComponent<MoveToMatObject>().enabled = false;
        GetComponent<Patrol>().enabled = false;
        GetComponent<Escape>().enabled = false;
        GetComponent<Stunned>().enabled = false;
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

                if (gameObject.GetComponent<MoveToMatObject>().enabled == true)
                {
                    gameObject.GetComponent<MoveToMatObject>().enabled = false;
                }


            }
            else
            {
                gameObject.GetComponent<StayPos>().enabled = false;
                if (!enemyStunned && !objectGrabbed)
                {
                    if (objectToSteal)
                    {
                        if (stealObject)
                        {
                            GetComponent<StoleItem>().enabled = true;
                            GetComponent<MoveToMatObject>().enabled = false;
                            GetComponent<Patrol>().enabled = false;
                            audioSource.PlayOneShot(laugh);
                        }
                        else
                        {
                            GetComponent<MoveToMatObject>().enabled = true;
                            GetComponent<Patrol>().enabled = false;
                            GetComponent<StoleItem>().enabled = false;
                        }

                    }
                    else
                    {
                        GetComponent<Patrol>().enabled = true;
                        GetComponent<MoveToMatObject>().enabled = false;
                        GetComponent<StoleItem>().enabled = false;
                        
                    }
                }
                else if(!enemyStunned && objectGrabbed)
                {
                    GetComponent<Escape>().enabled = true;
                }

                if (enemyStunned)
                {
                    GetComponent<Stunned>().enabled = true;
                    GetComponent<Patrol>().enabled = false;
                    GetComponent<MoveToMatObject>().enabled = false;
                    GetComponent<StoleItem>().enabled = false;
                    GetComponent<Escape>().enabled = false;
                    objectGrabbed = false;
                }
            }
        }
    }

    public void CheckPosObject(Transform pos)
    {
        NavMeshPath navMeshStatus = new NavMeshPath();
        nma.CalculatePath(pos.position, navMeshStatus);

        if (navMeshStatus.status == NavMeshPathStatus.PathComplete)
        {
            objectToSteal = true;
            objectPos = pos;
        }
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
