using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMemory : MonoBehaviour
{
    [SerializeField] List<GameObject> pieces;
    GameObject firstPieceGO;
    [SerializeField] float showTime;
    [SerializeField] private GameObject portalBlueEnable, bluePiece, dialogComeBack;
    float actualTimer;
    string firstLetter, secondPiece;
    int count, puzzleCount;
    bool showed;

    void OnEnable()
    {
        foreach(GameObject piece in pieces)
        {
            piece.GetComponent<PiecePuzzleMemory>().ShowPiece();
        }

        actualTimer = showTime;
    }

    void Update()
    {
        if(actualTimer > 0)
            actualTimer -= Time.deltaTime;

        if(actualTimer <= 0 && !showed)
        {
            foreach(GameObject piece in pieces)
            {
                piece.GetComponent<PiecePuzzleMemory>().HidePiece();
            }
            showed = true;
        }
    }

    public void HitPiece(GameObject piece, string letter)
    {
        piece.GetComponent<PiecePuzzleMemory>().ShowPiece();

        if (count == 0)
        {
            firstLetter = letter;
            count++;
            firstPieceGO = piece;
        }
        else
        {
            if(letter == firstLetter)
            {
                print("Correcto");
                puzzleCount++;
                firstPieceGO.GetComponent<PiecePuzzleMemory>().correct = true;
                piece.GetComponent<PiecePuzzleMemory>().correct = true;

                if (puzzleCount == 4)
                {
                    print("Gane Puzzle");
                    portalBlueEnable.GetComponent<Collider>().enabled = true;
                    bluePiece.SetActive(true);
                    dialogComeBack.SetActive(true);
                }
            }
            else
            {
                print("Incorrecto");
                firstPieceGO.GetComponent<PiecePuzzleMemory>().HidePiece();
                piece.GetComponent<PiecePuzzleMemory>().HidePiece();
                firstPieceGO.GetComponent<PiecePuzzleMemory>().guess = true;
                piece.GetComponent<PiecePuzzleMemory>().guess = true;
            }
            count = 0;
        }
    }
}
