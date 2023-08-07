using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterEnemy : MonoBehaviour
{
    [SerializeField] Material blue, red, actualMaterial;
    MeshRenderer meshRenderer;
    [SerializeField] float timer, valueTime;
    public float actualTimer;
    bool cantChange, isBlue;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = blue;
        actualTimer = timer;
        isBlue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!cantChange)
            actualTimer -= Time.deltaTime;

        if(actualTimer < 0)
        {
            if(isBlue)
            {
                meshRenderer.material = red;
                isBlue = false;
            }
            else
            {
                meshRenderer.material = blue;
                isBlue = true;
            }
            actualTimer = timer;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.layer == 18)
        {
            cantChange = true;
        }

        if (other.gameObject.tag == "Player")
        {
            if(isBlue == false)
            {
                GameObject.Find("TimerController").GetComponent<TimerController>().SubstractTime(valueTime);
            }
            else
            {
                GameObject.Find("TimerController").GetComponent<TimerController>().AddTime(valueTime);
            }
            Destroy(gameObject);
        }
    }
}