using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoleItem : MonoBehaviour
{
    GameObject matObj;
    [SerializeField] GameObject rulerInEnemy, cubeInEnemy;

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
        GetComponent<ThierfEnemyDecisions>().ObjectGrabbed = true;
        GetComponent<ThierfEnemyDecisions>().ObjectToSteal = false;
        Destroy(matObj);
        this.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
