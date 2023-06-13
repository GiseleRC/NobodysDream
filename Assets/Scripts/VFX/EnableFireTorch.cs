using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFireTorch : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        ps.Pause();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFire()
    {
        ps.Play();
        audioSource.Play();
    }
}
