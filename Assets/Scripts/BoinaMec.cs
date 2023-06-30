using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoinaMec : MonoBehaviour
{
    [SerializeField] GameObject boina;
    [SerializeField] Transform spawnPos;
    bool cantUse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool CantUse
    {
        set { cantUse = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Boina") && !cantUse)
        {
            Instantiate(boina, spawnPos.position, GameObject.Find("PlayerCam").GetComponent<Transform>().transform.rotation);
            cantUse = true;
        }
    }
}
