using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    //- Este script controla el tiempo de todo el nivel, no se resetea a menos que reinicies la escena y le tranfiere informacion al time del canvas
    [SerializeField] private float timeWait = 600f;
    [SerializeField] private float minTimeForPickBooster = 550f;
    public bool pickBooster = false;
    private int enemiesAttacking;
    public Image image;
    public Slider time;
    public Transform playerSC;
    public AudioSource clock;
    public AudioClip clockSlow, clockFast;
    private float currTimeWait;

    public int EnemiesAttacking
    {
        set { enemiesAttacking += value; }
        get { return enemiesAttacking; }
    }
    public float GetCurrTme()
    {
        return currTimeWait;
    }
    public void AddTime(float time)
    {
        currTimeWait += time;
    }

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    void Start()
    {
        currTimeWait = timeWait;
        time.value = timeWait;
    }
    void Update()
    {
        if (pickBooster && currTimeWait <= minTimeForPickBooster)
        {
            currTimeWait += 50;
            pickBooster = false;
        }

        if (enemiesAttacking >= 1)
        {
            currTimeWait -= Time.deltaTime * 2;
            image.color = Color.blue;
            if (clock.clip != clockFast)
            {
                clock.clip = clockFast;
                clock.Play();
            } 
        }
        else
        {
            currTimeWait -= Time.deltaTime;
            image.color = Color.white;
            if(clock.clip != clockSlow)
            {
                clock.clip = clockSlow;
                clock.Play();
            }
        }

        time.value = currTimeWait;
        if (currTimeWait <= 0)
        {
            SceneManager.LoadScene("Level1");
            currTimeWait = timeWait;
            image.color = Color.white;
        }
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
