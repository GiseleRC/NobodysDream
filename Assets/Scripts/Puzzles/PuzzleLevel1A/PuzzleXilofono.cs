using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleXilofono : MonoBehaviour
{
    public GameObject yellowPiece, xilofonoGO, missingPiecesGO, portalExitGO, portalEnterGO, xilofonoSensorsGO;
    public bool keyYellowDis, keyRedDis, keyOrangeDis, xilofonoEnable, xilofonoComplete, portalEnable;

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
    }
}
