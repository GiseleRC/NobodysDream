using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    bool umbrella, cantUseUmbrella;
    AudioSource audioSource;
    [SerializeField]GroundCheck ground;
    MaterializeObjects mtObjs;
    [SerializeField] float maxTimeUmbrella, rechargeSpeed, dischargeSpeed;
    float actualTime;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mtObjs = GetComponentInParent<MaterializeObjects>();
        actualTime = maxTimeUmbrella;
    }

    public bool UmbrellaActivate
    {
        get { return umbrella; }
    }

    public float MaxTimeUmbrella
    {
        get { return maxTimeUmbrella; }
    }

    public float ActualTime
    {
        get { return actualTime; }
    }

    public bool CantUseUmbrella
    {
        get { return cantUseUmbrella; }
        set { cantUseUmbrella = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action1") && !cantUseUmbrella && mtObjs.materializanding == false)
        {
            if (umbrella)
            {
                audioSource.Play();
                umbrella = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                audioSource.Play();
                umbrella = true;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if (cantUseUmbrella && ground.IsGrounded)
        {
            cantUseUmbrella = false;
        }

        if (umbrella)
        {
            actualTime -= dischargeSpeed * Time.deltaTime;
        }
        else
        {
            if (ground.IsGrounded)
            {
                if(actualTime < maxTimeUmbrella)
                {
                    actualTime += rechargeSpeed * Time.deltaTime;
                }
            }
        }
    }

    public void DestroyUmbrella()
    {
        umbrella = false;
        audioSource.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        cantUseUmbrella = true;
    }
}
