using System;
using UnityEngine;

public class EmptyPieceManager : MonoBehaviour
{
    public bool CheckAnswer()
    {
        foreach (var piece in GetComponentsInChildren<EmptyPiece>())
        {
            if (!piece.IsEnumEqual())
            {
                return false;
            }
        }
        return true;
    }
}