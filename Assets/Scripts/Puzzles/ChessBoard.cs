using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] public ChessPiece[] chessPieces;

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "Char")
        //{

        //}
    }
    public void ResetBoard()
    {
        foreach (ChessPiece chessPiece in chessPieces)
        {
            chessPiece.ResetPosition();
        }
    }
}
