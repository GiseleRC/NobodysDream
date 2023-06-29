using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFireTorch : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private AudioSource fireSound, clockSound;
    void Start()
    {
       // ps.Pause();
      //audioSource = GetComponent<AudioSource>();
    }

    public void PlayFire()
    {
        ps.Play();
        clockSound.Play();
        fireSound.PlayDelayed(1f);
    }
}
