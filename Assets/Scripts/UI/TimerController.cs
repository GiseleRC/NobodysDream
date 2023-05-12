using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timeWait = 1000f;
    public float currTimeWait;
    public bool pickBooster = false;
    public Image image;
    public Slider time;
    public Transform playerSC;
    int enemiesAttacking;

    public int EnemiesAttacking
    {
        set { enemiesAttacking += value; }
        get { return enemiesAttacking; }
    }

    void Start()
    {
        currTimeWait = timeWait;
        time.value = timeWait;
    }

    void Update()
    {
        if (pickBooster)
        {
            currTimeWait += 50;
            pickBooster = false;
        }
        if (enemiesAttacking >= 1)
        {
            currTimeWait -= Time.deltaTime * 2;
            image.color = Color.red;
        }
        else
        {
            currTimeWait -= Time.deltaTime;
            image.color = Color.white;
        }
        time.value = currTimeWait;
        if (currTimeWait <= 0)
        {
            SceneManager.LoadScene("Level1");
            currTimeWait = timeWait;
            image.color = Color.white;
        }
    }
}
