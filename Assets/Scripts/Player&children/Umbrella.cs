using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    bool umbrella, cantUseUmbrella, canRecharge, umbrellaDischarge;
    AudioSource audioSource;
    [SerializeField]GroundCheck ground;
    MaterializeObjects mtObjs;
    [SerializeField] float maxTimeUmbrella, rechargeSpeed, dischargeSpeed;
    float actualTime;
    [SerializeField] GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mtObjs = GetComponentInParent<MaterializeObjects>();
        actualTime = maxTimeUmbrella;
    }

    private void OnEnable()
    {
        ui.SetActive(true);
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
        if (Input.GetButtonDown("Action1") && !cantUseUmbrella && mtObjs.materializanding == false && !umbrellaDischarge)
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
            if (!ground.IsGrounded)
            {
                canRecharge = false;
                actualTime -= dischargeSpeed * Time.deltaTime;
                if(actualTime < 0)
                {
                    umbrellaDischarge = true;
                }
            }
            else
            {
                canRecharge = true;
            }
        }

        if (ground.IsGrounded && canRecharge && !umbrellaDischarge)
        {
            actualTime += rechargeSpeed * Time.deltaTime;
        }

        if (umbrellaDischarge)
        {
            actualTime += rechargeSpeed * Time.deltaTime;

            audioSource.Play();
            umbrella = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            if (actualTime >= maxTimeUmbrella)
            {
                actualTime = maxTimeUmbrella;
                umbrellaDischarge = false;
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
