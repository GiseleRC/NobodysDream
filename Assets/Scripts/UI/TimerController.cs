using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timeWait = 1000f;
    public float currTimeWait;
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
        print(enemiesAttacking);

        if (enemiesAttacking >= 1)
        {
            currTimeWait -= Time.deltaTime * 2;
            image.color = Color.red;
        }
        else
        {
            currTimeWait -= Time.deltaTime;
        }
        time.value = currTimeWait;
        if (currTimeWait <= 0)
        {
            SceneManager.LoadScene("Level1");
            currTimeWait = timeWait;
            image.color = Color.white;
        }
    }

    public void TimeRunFaster()
    {

    }

}
