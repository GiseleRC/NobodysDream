using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] public ChessPiece[] chessPieces;
    public bool torreB, peon1B, peon2B, alfilB, caballoB, peon3B;
    public GameObject letterGO, victoryBoardGO, rudolfGO, buttonResetGO;
    public DialogManager dialogManager;

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
            dialogManager.ShowDialog(DialogKey.Searching);
            letterGO.SetActive(false);
            victoryBoardGO.SetActive(true);
            rudolfGO.SetActive(true);
            buttonResetGO.SetActive(false);
            peon1B = false;
        }
    }
}
