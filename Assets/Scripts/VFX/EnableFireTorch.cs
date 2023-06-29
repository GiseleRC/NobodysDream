using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFireTorch : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
       // ps.Pause();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }

    public void PlayFire()
    {
        ps.Play();
        audioSource.Play();
    }
}
