using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public enum answerEnum
{
    TrueAnswer,
    FalseAnswer
}

public class AnswerCheckerBtn : MonoBehaviour
{
    [SerializeField] private AnswerCheck answerCheck;
    [SerializeField] private MiniGames miniGame;
    private TextMeshProUGUI text;

    private List<string> unAnswerList = new List<string>();

    public answerEnum answerEnum;

    private string unAnswerText;

    private void Awake()
    {
        text = GetComponentInChildren   <TextMeshProUGUI>();
    }

    private void Start()
    {
        if (answerEnum == answerEnum.FalseAnswer)
        {
            unAnswerList = miniGame.unAnswer;
            int rand = Random.Range(0, miniGame.unAnswer.Count);
            unAnswerText = miniGame.unAnswer[rand];
            miniGame.unAnswer.RemoveAt(rand);
        }
        else if(answerEnum == answerEnum.TrueAnswer)
        {
            unAnswerText = miniGame.GetAnswer();
        }

        text.SetText(unAnswerText);
    }

    public void AnswerSet()
    {
        answerCheck.AnswerChecker(unAnswerText);
    }
}
