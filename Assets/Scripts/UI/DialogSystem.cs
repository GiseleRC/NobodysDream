using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] public bool capB, flashlB, rullerB, slideB, bookB, rubberB, boosterB, crayonsB, chocolatesB, ghostB,
                                littleGB, candyWheelB, glassesB, pillsB, bottleB, fakeWindowB, trueWindowB, leve2B, ballpickeableB, 
                                bucketB, practiceB, firstDianaB, wallsB, darkB, fallB, respawnB;
    [SerializeField] public GameObject cap, flashl, ruller, slide, book, rubber, booster, crayons, chocolates, ghost,
                                littleG, candyWheel, glasses, pills, bottle, fakeWindow, trueWindow, leve2, ballpickeable,
                                bucket, practice, firstDiana, walls, dark, fall, respawn;
    //CAP ACTIVO, 
    private float waitTime = 6f;
    private void Update()
    {
        if (capB)
        {
            cap.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                cap.SetActive(false);
                capB = false;
                waitTime = 6f;
            }
        }
        else if (flashlB)
        {
            flashl.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                flashl.SetActive(false);
                flashlB = false;
                waitTime = 6f;
            }
        }
        else if (rullerB)
        {
            ruller.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                ruller.SetActive(false);
                rullerB = false;
                waitTime = 6f;
            }
        }
        else if (slideB)
        {
            slide.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                slide.SetActive(false);
                slideB = false;
                waitTime = 6f;
            }
        }
        else if (bookB)
        {
            slide.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                slide.SetActive(false);
                slideB = false;
                waitTime = 6f;
            }
        }
        else if (rubberB)
        {
            cap.SetActive(true);
        }
        else if (boosterB)
        {
            cap.SetActive(true);
        }
        else if (crayonsB)
        {
            cap.SetActive(true);
        }
        else if (chocolatesB)
        {
            cap.SetActive(true);
        }
        else if (ghostB)
        {
            cap.SetActive(true);
        }
        else if (littleGB)
        {
            cap.SetActive(true);
        }
        else if (candyWheelB)
        {
            cap.SetActive(true);
        }
        else if (glassesB)
        {
            cap.SetActive(true);
        }
        else if (pillsB)
        {
            cap.SetActive(true);
        }
        else if (bottleB)
        {
            cap.SetActive(true);
        }
        else if (fakeWindowB)
        {
            cap.SetActive(true);
        }
        else if (trueWindowB)
        {
            cap.SetActive(true);
        }
        else if (leve2B)
        {
            cap.SetActive(true);
        }
        else if (ballpickeableB)
        {
            cap.SetActive(true);
        }
        else if (bucketB)
        {
            cap.SetActive(true);
        }
        else if (practiceB)
        {
            cap.SetActive(true);
        }
        else if (firstDianaB)
        {
            cap.SetActive(true);
        }
        else if (wallsB)
        {
            cap.SetActive(true);
        }
        else if (darkB)
        {
            cap.SetActive(true);
        }
        else if (fallB)
        {
            cap.SetActive(true);
        }
        else if (respawnB)
        {
            cap.SetActive(true);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Char")
        {
            if (gameObject.name == "ChocolateBlock")
            {
                slideB = true;
            }
        }

    }
}
