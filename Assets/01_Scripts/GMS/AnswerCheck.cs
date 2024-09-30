using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    public MiniGames game;
    public string answer;

    public void AnswerChecker()
    {
        bool isClear = game.AnswerCheck(answer);
        StartCoroutine(game.Typing(isClear));
    }
}
