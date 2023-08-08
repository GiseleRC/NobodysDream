using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocatePIecesXilophone : MonoBehaviour
{
    [SerializeField] GameObject piece, clavo1, clavo2, nextTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char")
        {
            gameObject.GetComponent<EnableBucketUI>().EnableUI();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Char")
        {
            if (Input.GetButton("Interact"))
            {
                piece.SetActive(true);
                clavo1.SetActive(true);
                clavo2.SetActive(true);
                GameObject.Find("Puzzle - Yellow Triangle").GetComponent<PuzzleXilofono>().CheckStatusKeyPlaced();
                gameObject.GetComponent<EnableBucketUI>().DisableUI();
                gameObject.SetActive(false);

                if(nextTrigger != null)
                {
                    nextTrigger.SetActive(true);
                }

                if(gameObject.name == "TriggerRed")
                {
                    GameObject.Find("Puzzle - Yellow Triangle").GetComponent<PuzzleXilofono>().keyRedPlaced = true;

                }else if(gameObject.name == "TriggerOrange")
                {
                    GameObject.Find("Puzzle - Yellow Triangle").GetComponent<PuzzleXilofono>().keyOrangePlaced = true;
                }
                else
                {
                    GameObject.Find("Puzzle - Yellow Triangle").GetComponent<PuzzleXilofono>().keyYellowPlaced = true;
                }
                GameObject.Find("Puzzle - Yellow Triangle").GetComponent<PuzzleXilofono>().CheckStatusKeyPlaced();
                gameObject.GetComponent<EnableBucketUI>().DisableUI();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Char")
        {
            gameObject.GetComponent<EnableBucketUI>().DisableUI();
        }
    }
}
