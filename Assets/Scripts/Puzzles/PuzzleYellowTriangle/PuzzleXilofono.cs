using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleXilofono : MonoBehaviour
{
    public GameObject yellowPiece, xilofonoGO, missingPiecesGO, portalExitGO, portalEnterGO, xilofonoSensorsGO, redKeyUI,
        orangeKeyUI, yellowKeyUI, xilophoneCompleteGO, finalPosXilophone, yellowTriangle, level1AfterPuzzle, particlePortalYellow;
    public bool keyYellowDis, keyRedDis, keyOrangeDis, xilofonoEnable, xilofonoComplete, portalEnable, keyRedPlaced, keyYellowPlaced, keyOrangePlaced, moveXilophoneGO;
    bool changeSpawn;
    public AudioSource puzzleHasBeenPass;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] Transform newSpawn;

    void Update()
    {
        if(keyRedDis && keyYellowDis && keyOrangeDis)
        {
            puzzleHasBeenPass.Play();
            portalEnable = true;
            xilofonoGO.SetActive(true);
            portalExitGO.GetComponent<BoxCollider>().enabled = true;
            portalEnterGO.SetActive(true);
            xilofonoSensorsGO.SetActive(true);
            particlePortalYellow.SetActive(true);
        }

        if (xilofonoComplete)
        {
            missingPiecesGO.SetActive(true);
        }

        if (moveXilophoneGO)
        {
            xilophoneCompleteGO.transform.position = Vector3.SmoothDamp(xilophoneCompleteGO.transform.position, finalPosXilophone.transform.position, ref velocity, 250f * Time.deltaTime);
            if(yellowTriangle != null)
                yellowTriangle.SetActive(true);
            DisableKeyUI();

            level1AfterPuzzle.SetActive(true);

            SpawnPlayerController spawnPlayer = GameObject.Find("SpawnPlayerController").GetComponent<SpawnPlayerController>();

            if (!changeSpawn)
            {
                spawnPlayer.Respawn(newSpawn);
                changeSpawn = true;
            }

        }

        float distance = Vector3.Distance(xilophoneCompleteGO.transform.position, finalPosXilophone.transform.position);

        if(distance < 0.5f)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowKeyUI()
    {
        redKeyUI.SetActive(true);
        orangeKeyUI.SetActive(true);
        yellowKeyUI.SetActive(true);
    }

    public void DisableKeyUI()
    {
        redKeyUI.SetActive(false);
        orangeKeyUI.SetActive(false);
        yellowKeyUI.SetActive(false);
    }

    public void CheckStatusKeyPlaced()
    {
        if(keyYellowPlaced && keyOrangePlaced && keyRedPlaced)
        {
            moveXilophoneGO = true;
        }
    }
}
