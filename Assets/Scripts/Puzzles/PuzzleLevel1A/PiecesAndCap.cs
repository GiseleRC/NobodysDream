using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesAndCap : MonoBehaviour
{
    [SerializeField] private PuzzleXilofono puzzleXilofono;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ThrowBoina(Clone)")
        {
            if(gameObject.name == "RedKey")
            {
                puzzleXilofono.keyRedDis = true;
                gameObject.SetActive(false);
            }
            else if (gameObject.name == "YellowKey")
            {
                puzzleXilofono.keyYellowDis = true;
                gameObject.SetActive(false);
            }
            else if (gameObject.name == "OrangeKey")
            {
                puzzleXilofono.keyOrangeDis = true;
                gameObject.SetActive(false);
            }
            else if (gameObject.name == "Xilofono")
            {
                puzzleXilofono.xilofonoComplete = true;
            }
        }
    }

    void Update()
    {
        
    }
}
