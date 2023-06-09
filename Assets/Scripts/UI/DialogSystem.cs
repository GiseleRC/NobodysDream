using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] public bool capB, flashlB, rullerB, slideB, bookB, bookEnableB, rubberB, boosterB, crayonsB, chocolatesB, ghostB,
                                littleGB, candyWheelB, glassesB, pillsB, bottleB, fakeWindowB, trueWindowB, level2B, ballpickeableB, 
                                bucketB, practiceB, firstDianaB, wallsB, darkB, fallB, respawnB;
    [SerializeField] public GameObject pickableBall, bkgrownd, cap, flashl, ruller, slide, book, bookEnable, rubber, booster, crayons, chocolates, ghost,
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
        else if (bookEnableB)
        {
            bookEnable.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                bookEnable.SetActive(false);
                bkgrownd.SetActive(false);
                bookEnableB = false;
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
            glasses.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                glasses.SetActive(false);
                bkgrownd.SetActive(false);
                glassesB = false;
                waitTime = 6f;
            }
        }
        else if (pillsB)
        {
            pills.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                pills.SetActive(false);
                bkgrownd.SetActive(false);
                pillsB = false;
                waitTime = 6f;
            }
        }
        else if (bottleB)
        {
            bottle.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                bottle.SetActive(false);
                bkgrownd.SetActive(false);
                bottleB = false;
                waitTime = 6f;
            }
        }
        else if (fakeWindowB)
        {
            fakeWindow.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                fakeWindow.SetActive(false);
                bkgrownd.SetActive(false);
                fakeWindowB = false;
                waitTime = 6f;
            }
        }
        else if (trueWindowB)
        {
            trueWindow.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                trueWindow.SetActive(false);
                bkgrownd.SetActive(false);
                trueWindowB = false;
                waitTime = 6f;
            }
        }
        else if (level2B)
        {
            level2.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                level2.SetActive(false);
                bkgrownd.SetActive(false);
                level2B = false;
                waitTime = 4f;
                ballpickeableB = true;
            }
        }
        else if (ballpickeableB && pickableBall.gameObject.activeInHierarchy)
        {
            ballpickeable.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                ballpickeable.SetActive(false);
                bkgrownd.SetActive(false);
                waitTime = 4f;
                ballpickeableB = false;
            }
        }
        else if (bucketB)
        {
            bucket.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                bucket.SetActive(false);
                bkgrownd.SetActive(false);
                bucketB = false;
                waitTime = 6f;
            }
        }
        else if (practiceB)
        {
            practice.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                practice.SetActive(false);
                bkgrownd.SetActive(false);
                practiceB = false;
                waitTime = 6f;
            }
        }
        else if (firstDianaB)
        {
            firstDiana.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                firstDiana.SetActive(false);
                bkgrownd.SetActive(false);
                firstDianaB = false;
                waitTime = 6f;
            }
        }
        else if (wallsB)
        {
            walls.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                walls.SetActive(false);
                bkgrownd.SetActive(false);
                wallsB = false;
                waitTime = 6f;
            }
        }
        else if (darkB)
        {
            dark.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                dark.SetActive(false);
                bkgrownd.SetActive(false);
                darkB = false;
                waitTime = 6f;
            }
        }
        else if (fallB)
        {
            fall.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                fall.SetActive(false);
                bkgrownd.SetActive(false);
                fallB = false;
                waitTime = 6f;
            }
        }
        else if (respawnB)
        {
            respawn.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                respawn.SetActive(false);
                bkgrownd.SetActive(false);
                respawnB = false;
                waitTime = 6f;
            }
        }
    }
}
