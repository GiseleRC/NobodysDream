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
    private float waitTime = 8f;
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
                waitTime = 8f;
            }
        }
        else
        {
            cap.SetActive(false);
            waitTime = 8f;
        }

        if (flashlB)
        {
            if (capB)
                capB = false;

            flashl.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                flashl.SetActive(false);
                bkgrownd.SetActive(false);
                flashlB = false;
                waitTime = 8f;
            }
        }
        else
        {
            flashl.SetActive(false);
            waitTime = 8f;
        }

        if (rullerB)
        {
            if (flashlB)
                flashlB = false;

            ruller.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                ruller.SetActive(false);
                bkgrownd.SetActive(false);
                rullerB = false;
                waitTime = 8f;
            }
        }
        else
        {
            ruller.SetActive(false);
            waitTime = 8f;
        }

        if (slideB)
        {
            if (rullerB)
                rullerB = false;

            slide.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                slide.SetActive(false);
                bkgrownd.SetActive(false);
                slideB = false;
                waitTime = 8f;
            }
        }
        else
        {
            slide.SetActive(false);
            waitTime = 8f;
        }

        if (bookB)
        {
            if (slideB)
                slideB = false;

            book.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                book.SetActive(false);
                bkgrownd.SetActive(false);
                bookB = false;
                waitTime = 8f;
            }
        }
        else
        {
            book.SetActive(false);
            waitTime = 8f;
        }

        if (bookEnableB)
        {
            if (bookB)
                bookB = false;

            bookEnable.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                bookEnable.SetActive(false);
                bkgrownd.SetActive(false);
                bookEnableB = false;
                waitTime = 8f;
            }
        }
        else
        {
            bookEnable.SetActive(false);
            waitTime = 8f;
        }

        if (boosterB)
        {
            if (bookEnableB)
                bookEnableB = false;

            booster.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                booster.SetActive(false);
                bkgrownd.SetActive(false);
                boosterB = false;
                waitTime = 8f;
            }
        }
        else
        {
            booster.SetActive(false);
            waitTime = 8f;
        }

        if (rubberB)
        {
            if (boosterB)
                boosterB = false;

            rubber.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                rubber.SetActive(false);
                bkgrownd.SetActive(false);
                rubberB = false;
                waitTime = 8f;
            }
        }
        else
        {
            rubber.SetActive(false);
            waitTime = 8f;
        }

        if (crayonsB)
        {
            if (rubberB)
                rubberB = false;

            crayons.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                crayons.SetActive(false);
                bkgrownd.SetActive(false);
                crayonsB = false;
                waitTime = 8f;
            }
        }
        else
        {
            crayons.SetActive(false);
            waitTime = 8f;
        }

        if (chocolatesB)
        {
            if (crayonsB)
                crayonsB = false;

            chocolates.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                chocolates.SetActive(false);
                bkgrownd.SetActive(false);
                chocolatesB = false;
                waitTime = 8f;
            }
        }
        else
        {
            chocolates.SetActive(false);
            waitTime = 8f;
        }

        if (ghostB)
        {
            if (chocolatesB)

            ghost.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                ghost.SetActive(false);
                bkgrownd.SetActive(false);
                ghostB = false;
                waitTime = 8f;
            }
        }
        else
        {
            ghost.SetActive(false);
            waitTime = 8f;
        }

        if (littleGB)
        {
            if (ghostB)
                ghostB = false;

            littleG.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                littleG.SetActive(false);
                bkgrownd.SetActive(false);
                littleGB = false;
                waitTime = 8f;
            }
        }
        else
        {
            littleG.SetActive(false);
            waitTime = 8f;
        }

        if (candyWheelB)
        {
            if (littleGB)
                littleGB = false;

            candyWheel.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                candyWheel.SetActive(false);
                bkgrownd.SetActive(false);
                candyWheelB = false;
                waitTime = 8f;
            }
        }
        else
        {
            candyWheel.SetActive(false);
            waitTime = 8f;
        }

        if (glassesB)
        {
            if (candyWheelB)
                candyWheelB = false;

            glasses.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                glasses.SetActive(false);
                bkgrownd.SetActive(false);
                glassesB = false;
                waitTime = 8f;
            }
        }
        else
        {
            glasses.SetActive(false);
            waitTime = 8f;
        }

        if (pillsB)
        {
            if (glassesB)
                glassesB = false;

            pills.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                pills.SetActive(false);
                bkgrownd.SetActive(false);
                pillsB = false;
                waitTime = 8f;
            }
        }
        else
        {
            pills.SetActive(false);
            waitTime = 8f;
        }

        if (bottleB)
        {
            if (pillsB)
                pillsB = false;

            bottle.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                bottle.SetActive(false);
                bkgrownd.SetActive(false);
                bottleB = false;
                waitTime = 8f;
            }
        }
        else
        {
            bottle.SetActive(false);
            waitTime = 8f;
        }

        if (fakeWindowB)
        {
            if (bottleB)
                bottleB = false;

            fakeWindow.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                fakeWindow.SetActive(false);
                bkgrownd.SetActive(false);
                fakeWindowB = false;
                waitTime = 8f;
            }
        }
        else
        {
            fakeWindow.SetActive(false);
            waitTime = 8f;
        }

        if (trueWindowB)
        {
            if (fakeWindowB)
                fakeWindowB = false;

            trueWindow.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                trueWindow.SetActive(false);
                bkgrownd.SetActive(false);
                trueWindowB = false;
                waitTime = 8f;
            }
        }
        else
        {
            trueWindow.SetActive(false);
            waitTime = 8f;
        }

        if (level2B)
        {
            if (trueWindowB)
                trueWindowB = false;

            level2.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                level2.SetActive(false);
                bkgrownd.SetActive(false);
                level2B = false;
                waitTime = 8f;
                ballpickeableB = true;
            }
        }
        else
        {
            level2.SetActive(false);
            waitTime = 8f;
        }

        if (ballpickeableB && pickableBall.gameObject.activeInHierarchy)
        {
            if (level2B)
                level2B = false;

            ballpickeable.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                ballpickeable.SetActive(false);
                bkgrownd.SetActive(false);
                waitTime = 8f;
                ballpickeableB = false;
            }
        }
        else
        {
            ballpickeable.SetActive(false);
            waitTime = 8f;
        }

        if (bucketB)
        {
            if (ballpickeableB)
                ballpickeableB = false;

            bucket.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                bucket.SetActive(false);
                bkgrownd.SetActive(false);
                bucketB = false;
                waitTime = 8f;
            }
        }
        else
        {
            bucket.SetActive(false);
            waitTime = 8f;
        }

        if (practiceB)
        {
            if (bucketB)
                bucketB = false;

            practice.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                practice.SetActive(false);
                bkgrownd.SetActive(false);
                practiceB = false;
                waitTime = 8f;
            }
        }
        else
        {
            practice.SetActive(false);
            waitTime = 8f;
        }

        if (firstDianaB)
        {
            if (practiceB)
                practiceB = false;

            firstDiana.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                firstDiana.SetActive(false);
                bkgrownd.SetActive(false);
                firstDianaB = false;
                waitTime = 8f;
            }
        }
        else
        {
            firstDiana.SetActive(false);
            waitTime = 8f;
        }

        if (wallsB)
        {
            if (firstDianaB)
                firstDianaB = false;

            walls.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                walls.SetActive(false);
                bkgrownd.SetActive(false);
                wallsB = false;
                waitTime = 8f;
            }
        }
        else
        {
            walls.SetActive(false);
            waitTime = 8f;
        }

        //if (darkB)
        //{

        //    dark.SetActive(true);
        //    bkgrownd.SetActive(true);
        //    waitTime -= Time.deltaTime;
        //    if (waitTime <= 0)
        //    {
        //        dark.SetActive(false);
        //        bkgrownd.SetActive(false);
        //        darkB = false;
        //        waitTime = 6f;
        //    }
        //}
        //else if (fallB)
        //{
        //    fall.SetActive(true);
        //    bkgrownd.SetActive(true);
        //    waitTime -= Time.deltaTime;
        //    if (waitTime <= 0)
        //    {
        //        fall.SetActive(false);
        //        bkgrownd.SetActive(false);
        //        fallB = false;
        //        waitTime = 6f;
        //    }
        //}
        //else if (respawnB)
        //{
        //    respawn.SetActive(true);
        //    bkgrownd.SetActive(true);
        //    waitTime -= Time.deltaTime;
        //    if (waitTime <= 0)
        //    {
        //        respawn.SetActive(false);
        //        bkgrownd.SetActive(false);
        //        respawnB = false;
        //        waitTime = 6f;
        //    }
        //}
    }
}
