using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject currDialog; 
    [SerializeField] public bool capB, flashlB, rullerB, slideB, bookB, bookEnableB, rubberB, boosterB, crayonsB, chocolatesB, ghostB,
                                littleGB, candyWheelB, glassesB, pillsB, bottleB, fakeWindowB, trueWindowB, level2B, ballpickeableB, 
                                bucketB, practiceB, firstDianaB, wallsB, darkB, fallB, respawnB;
    [SerializeField] public GameObject pickableBall, bkgrownd, cap, flashl, ruller, slide, book, bookEnable, rubber, booster, crayons, chocolates, ghost,
                                littleG, candyWheel, glasses, pills, bottle, fakeWindow, trueWindow, level2, ballpickeable,
                                bucket, practice, firstDiana, walls, dark, fall, respawn;
    //CAP ACTIVO, 
    private float waitTime = 10f;
    private void Update()
    {
        if (capB)
        {
            cap.SetActive(true);
            currDialog = cap;
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
            capB = false;
            flashl.SetActive(true);
            currDialog = flashl;
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
            flashlB = false;
            currDialog = ruller;
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
            rullerB = false;
            currDialog = slide;
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
            slideB = false;
            currDialog = book;
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
            bookB = false;
            currDialog = bookEnable;
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
            bookEnableB = false;
            currDialog = rubber;
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
            rubberB = false;
            currDialog = booster;
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
            boosterB = false;
            currDialog = crayons;
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
            crayonsB = false;
            currDialog = chocolates;
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
            chocolatesB = false;
            currDialog = ghost;
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
            ghostB = false;
            currDialog = littleG;
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
            littleGB = false;
            currDialog = candyWheel;
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
            candyWheelB = false;
            currDialog = glasses;
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
            glassesB = false;
            currDialog = pills;
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
            pillsB = false;
            currDialog = bottle;
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
            bottleB = false;
            currDialog = fakeWindow;
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
            fakeWindowB = false;
            currDialog = trueWindow;
            trueWindow.SetActive(true);
            bkgrownd.SetActive(true);
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                trueWindow.SetActive(false);
                bkgrownd.SetActive(false);
                trueWindowB = false;
                waitTime = 3f;
            }
        }
        else if (level2B)
        {
            trueWindowB = false;
            currDialog = level2;
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
            level2B = false;
            currDialog = ballpickeable;
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
            ballpickeableB = false;
            currDialog = bucket;
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
            bucketB = false;
            currDialog = practice;
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
            practiceB = false;
            currDialog = firstDiana;
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
            firstDianaB = false;
            currDialog = walls;
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
        else
        {
            currDialog.SetActive(false);
            bkgrownd.SetActive(false);
        }
    }
}
