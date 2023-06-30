using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] public ChessPiece[] chessPieces;
    [SerializeField] private ChessSensors chessSensors;
    public bool torreB, peon1B, peon2B, alfilB, caballoB, peon3B;
    public GameObject letterGO, victoryBoardGO, rudolfGO, buttonResetGO;
    public DialogManager dialogManager;

    public void ResetBoard()
    {
        foreach (ChessPiece chessPiece in chessPieces)
        {
            chessPiece.ResetPosition();
        }
        chessSensors.peon1Bpart.SetActive(true);
        chessSensors.peon2Bpart.SetActive(true);
        chessSensors.peon3Bpart.SetActive(true);
        chessSensors.torreBpart.SetActive(true);
        chessSensors.alfilBpart.SetActive(true);
        chessSensors.caballoBpart.SetActive(true);
    }

    private void Update()
    {
        if (peon1B && peon2B && peon3B && torreB && alfilB && caballoB)
        {
            letterGO.SetActive(false);
            buttonResetGO.SetActive(false);
            dialogManager.ShowDialog(DialogKey.Searching);
            victoryBoardGO.SetActive(true);
            rudolfGO.SetActive(true);
            peon1B = false;
        }
    }
}
