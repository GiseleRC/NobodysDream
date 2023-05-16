using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    float posZ;
    [SerializeField]Color red, blue;
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        if(gameObject.transform.position.z < posZ)
        {
            main.startColor = red;
        }
        else
        {
            main.startColor = blue;
        }

        posZ = gameObject.transform.position.z;
    }
}
