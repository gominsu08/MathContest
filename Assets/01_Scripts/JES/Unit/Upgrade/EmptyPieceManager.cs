using System;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPieceManager : MonoBehaviour
{
    private List<EmptyPiece> emptyPieces = new List<EmptyPiece>();

    private void Start()
    {
        foreach (var piece in GetComponentsInChildren<EmptyPiece>())
        {
            emptyPieces.Add(piece);
        }
    }

    public bool CheckAnswer()
    {
        foreach (var piece in emptyPieces)
        {
            if (!piece.IsEnumEqual())
            {
                return false;
            }
        }
        return true;
    }

    public void ResetPiece(bool value =false)
    {
        foreach (var piece in emptyPieces)
        {
            piece.Reset(value);
        }
    }
}