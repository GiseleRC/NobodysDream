using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dianas : MonoBehaviour
{
    public Puzzle2 puzzle2;
    public Puzzle3 puzzle3;
    private Vector3 position1;
    public GameObject tabGO, firstPos, facesGO1, facesGO2, facesGO3;

    private void Start()
    {
        position1 = tabGO.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            if (gameObject.name == "Diana1")
            {
                puzzle2.doorEnable1 = true;
            }
            if (gameObject.name == "Diana2")
            {
                puzzle2.doorEnable2 = true;
            }
            if (gameObject.name == "Diana3")
            {
                puzzle2.doorEnable3 = true;
            }

            if (gameObject.name == "Nose1")
            {
                puzzle3.showGuess1 = true;
                facesGO1.transform.Rotate(0, 180, 0);
            }
            if (gameObject.name == "Nose2")
            {
                puzzle3.showGuess2 = true;
                facesGO2.transform.Rotate(0, 180, 0);
            }
            if (gameObject.name == "Nose3")
            {
                puzzle3.showGuess3 = true;
                facesGO3.transform.Rotate(0, 180, 0);
            }

            if (gameObject.name == "Option1")
            {
                gameObject.SetActive(false);
            }
            if (gameObject.name == "Option2")
            {
                gameObject.SetActive(false);
            }
            if (gameObject.name == "Option3")
            {
                gameObject.SetActive(false);
                position1 = new Vector3(position1.x, 5f, position1.z);
            }
        }
    }
}
