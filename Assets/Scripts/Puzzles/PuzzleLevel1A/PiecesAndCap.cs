using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiecesAndCap : MonoBehaviour
{
    [SerializeField] private PuzzleXilofono puzzleXilofono;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char")
        {
            if(gameObject.name == "RedKey")
            {
                puzzleXilofono.keyRedDis = true;
                gameObject.SetActive(false);
                GameObject.Find("RedKeyUI").GetComponent<Image>().color = Color.white;
            }
            else if (gameObject.name == "YellowKey")
            {
                puzzleXilofono.keyYellowDis = true;
                gameObject.SetActive(false);
                GameObject.Find("YellowKeyUI").GetComponent<Image>().color = Color.white;
            }
            else if (gameObject.name == "OrangeKey")
            {
                puzzleXilofono.keyOrangeDis = true;
                gameObject.SetActive(false);
                GameObject.Find("OrangeKeyUI").GetComponent<Image>().color = Color.white;
            }
            else if (gameObject.name == "Xilofono")
            {
                puzzleXilofono.xilofonoComplete = true;
            }
        }
    }
}
