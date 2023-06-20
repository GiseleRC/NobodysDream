using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetChess : MonoBehaviour
{
    [SerializeField] ChessBoard chessBoard;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball(Clone)")
        {
            chessBoard.ResetBoard();
        }
    }
}
