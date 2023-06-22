using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] public ChessPiece[] chessPieces;
    public bool torreB, peon1B, peon2B, alfilB, caballoB, peon3B;
    public GameObject letterGO, victoryBoardGO, rudolfGO;

    public void ResetBoard()
    {
        foreach (ChessPiece chessPiece in chessPieces)
        {
            chessPiece.ResetPosition();
        }
    }

    private void Update()
    {
        if (peon1B && peon2B && peon3B && torreB && alfilB && caballoB)
        {
            letterGO.SetActive(false);
            victoryBoardGO.SetActive(true);
            rudolfGO.SetActive(true);
            peon1B = false;
            Debug.Log("update de los sendor pieces");

        }
    }
}
