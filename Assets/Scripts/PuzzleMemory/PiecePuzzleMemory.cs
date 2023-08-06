using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePuzzleMemory : MonoBehaviour
{
    [SerializeField] string letter;
    public bool correct, guess;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPiece()
    {
        transform.Rotate(0, 180, 0);
    }

    public void HidePiece()
    {
        transform.Rotate(0, 180, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 17 && !correct || other.gameObject.layer == 17 && !guess)
        {
            print("entre aca");
            GameObject.Find("MemoryPuzzle").GetComponent<PuzzleMemory>().HitPiece(gameObject, letter);
            guess = true;
        }
    }
}
