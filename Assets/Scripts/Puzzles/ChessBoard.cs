using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] public ChessPiece[] chessPieces;

    public void ResetBoard()
    {
        foreach (ChessPiece chessPiece in chessPieces)
        {
            chessPiece.ResetPosition();
        }
    }
}
