using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRedChessPiece : MonoBehaviour
{
    PuzzleRedCircle puzzleRedCircle;
    [SerializeField] string piece;
    // Start is called before the first frame update
    void Start()
    {
        puzzleRedCircle = GameObject.Find("PuzzleRedCircle").GetComponent<PuzzleRedCircle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Char")
        {
            puzzleRedCircle.SpawnPieceChess(piece);
            puzzleRedCircle.CheckStatusPieces();
            Destroy(gameObject);
        }
    }
}
