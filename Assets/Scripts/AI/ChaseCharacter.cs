using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseCharacter : MonoBehaviour
{
    NavMeshAgent nma;
    AIDecisions AId;
    MeshRenderer mRen;
    [SerializeField] float minDistanceChar;
    [SerializeField]Material redEyes, whiteEyes;
    bool stunned;
    float actualTime;

    // Start is called before the first frame update
    void OnEnable()
    {
        actualTime = 0;
        mRen.material = redEyes;
    }

    void Start()
    {
        mRen = GameObject.Find("PM3D_Sphere3D1").GetComponent<MeshRenderer>();
        nma = GetComponent<NavMeshAgent>();
        AId = GetComponent<AIDecisions>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!stunned)
        {
            mRen.material = redEyes;
            if (AId.Distance < minDistanceChar)
            {
                gameObject.GetComponent<AIDecisions>().GhostAttack = true;
                nma.SetDestination(transform.position);
            }
            else
            {
                nma.SetDestination(AId.CharacterPos.position);
            }
        }
        else
        {
            nma.SetDestination(transform.position);
            actualTime -= Time.deltaTime;

            if (actualTime <= 0)
            {
                stunned = false;
            }
        }
    }

    public void Stunned(float stunDuration)
    {
        stunned = true;
        actualTime = stunDuration;
        mRen.material = whiteEyes;
    }
}
