using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetChess : MonoBehaviour
{
    [SerializeField] ChessBoard chessBoard;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball(Clone)")
        {
            chessBoard.ResetBoard();
        }
    }
}
