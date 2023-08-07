using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleXilofono : MonoBehaviour
{
    public GameObject yellowPiece, xilofonoGO, missingPiecesGO, portalExitGO, portalEnterGO, xilofonoSensorsGO, redKeyUI, orangeKeyUI, yellowKeyUI, xilophoneCompleteGO, finalPosXilophone;
    public bool keyYellowDis, keyRedDis, keyOrangeDis, xilofonoEnable, xilofonoComplete, portalEnable, keyRedPlaced, keyYellowPlaced, keyOrangePlaced, moveXilophoneGO;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if(keyRedDis && keyYellowDis && keyOrangeDis)
        {
            portalEnable = true;
            xilofonoGO.SetActive(true);
            portalExitGO.GetComponent<BoxCollider>().enabled = true;
            portalEnterGO.SetActive(true);
            xilofonoSensorsGO.SetActive(true);
        }

        if (xilofonoComplete)
        {
            missingPiecesGO.SetActive(true);
        }

        if (moveXilophoneGO)
        {
            xilophoneCompleteGO.transform.position = Vector3.SmoothDamp(xilophoneCompleteGO.transform.position, finalPosXilophone.transform.position, ref velocity, 250f * Time.deltaTime);
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
