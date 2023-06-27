using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    bool umbrella;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool UmbrellaActivate
    {
        get { return umbrella; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action1"))
        {
            if (umbrella)
            {
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
    }
}
