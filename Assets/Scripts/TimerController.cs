using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timeWait = 100f;
    public float currTimeWait;
    public Slider time;
    public Transform playerSC;

    void Start()
    {
        currTimeWait = timeWait;
        time.value = timeWait;
    }

    void Update()
    {
        currTimeWait -= Time.deltaTime;
        time.value = currTimeWait;
        if (currTimeWait <= 0)
        {
            SceneManager.LoadScene("Level1");
            currTimeWait = timeWait;
        }

        if (playerSC.position.y < -20)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
