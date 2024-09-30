using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    public MiniGames game;

    public void AnswerChecker(string answer)
    {
        bool isClear = game.AnswerCheck(answer);
        StartCoroutine(game.Typing(isClear));
    }
}
