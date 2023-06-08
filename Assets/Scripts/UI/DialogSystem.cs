using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] public bool capB, flashlB, rullerB, slideB, bookB, rubberB, boosterB, crayonsB, chocolatesB, ghostB,
                                littleGB, candyWheelB, glassesB, pillsB, bottleB, fakeWindowB, trueWindowB, level2B, ballpickeableB, 
                                bucketB, practiceB, firstDianaB, wallsB, darkB, fallB, respawnB;
    [SerializeField] public GameObject bkgrownd, cap, flashl, ruller, slide, book, rubber, booster, crayons, chocolates, ghost,
                                littleG, candyWheel, glasses, pills, bottle, fakeWindow, trueWindow, level2, ballpickeable,
                                bucket, practice, firstDiana, walls, dark, fall, respawn;
    //CAP ACTIVO, 
    private float waitTime = 6f;
    private void Update()
    {
        if (capB)
        {
            cap.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                cap.SetActive(false);
                bkgrownd.SetActive(false);
                capB = false;
                waitTime = 6f;
            }
        }
        else if (flashlB)
        {
            flashl.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                flashl.SetActive(false);
                bkgrownd.SetActive(false);
                flashlB = false;
                waitTime = 6f;
            }
        }
        else if (rullerB)
        {
            ruller.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                ruller.SetActive(false);
                bkgrownd.SetActive(false);
                rullerB = false;
                waitTime = 6f;
            }
        }
        else if (slideB)
        {
            slide.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                slide.SetActive(false);
                bkgrownd.SetActive(false);
                slideB = false;
                waitTime = 3f;
            }
        }
        else if (bookB)
        {
            book.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                book.SetActive(false);
                bkgrownd.SetActive(false);
                bookB = false;
                waitTime = 4f;
            }
        }
        else if (rubberB)
        {
            rubber.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                rubber.SetActive(false);
                bkgrownd.SetActive(false);
                rubberB = false;
                waitTime = 4f;
            }
        }
        else if (boosterB)
        {
            booster.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                booster.SetActive(false);
                bkgrownd.SetActive(false);
                boosterB = false;
                waitTime = 6f;
            }
        }
        else if (crayonsB)
        {
            crayons.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                crayons.SetActive(false);
                bkgrownd.SetActive(false);
                crayonsB = false;
                waitTime = 6f;
            }
        }
        else if (chocolatesB)
        {
            chocolates.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                chocolates.SetActive(false);
                bkgrownd.SetActive(false);
                chocolatesB = false;
                waitTime = 6f;
            }
        }
        else if (ghostB)
        {
            ghost.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                ghost.SetActive(false);
                bkgrownd.SetActive(false);
                ghostB = false;
                waitTime = 5f;
            }
        }
        else if (littleGB)
        {
            littleG.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                littleG.SetActive(false);
                bkgrownd.SetActive(false);
                littleGB = false;
                waitTime = 4f;
            }
        }
        else if (candyWheelB)
        {
            candyWheel.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                candyWheel.SetActive(false);
                bkgrownd.SetActive(false);
                candyWheelB = false;
                waitTime = 4f;
            }
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
        else if (level2B)
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
}
