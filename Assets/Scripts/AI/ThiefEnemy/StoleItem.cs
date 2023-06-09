using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoleItem : MonoBehaviour
{
    [SerializeField] public DialogSystem dialogS;
    GameObject matObj;
    [SerializeField] GameObject rulerInEnemy, cubeInEnemy;


    private void Start()
    {

    }

    void OnEnable()
    {
        matObj = GetComponent<ThierfEnemyDecisions>().ObjectPos.gameObject;
        if (matObj.tag == "Cube") 
        { 
            cubeInEnemy.SetActive(true);
        }
        else if(matObj.tag == "Ruler")
        {
            rulerInEnemy.SetActive(true);
        }
        dialogS.littleGB = true;
        GetComponent<ThierfEnemyDecisions>().ObjectGrabbed = true;
        GetComponent<ThierfEnemyDecisions>().ObjectToSteal = false;
        Destroy(matObj);
        this.enabled = false;
    }
}
