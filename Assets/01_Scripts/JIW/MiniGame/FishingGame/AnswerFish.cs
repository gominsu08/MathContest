using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Random = UnityEngine.Random;

public class AnswerFish : MonoBehaviour
{
    private TextMeshPro _textMesh;
    private string _myAnswer;

    private void Start()
    {
        _textMesh = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public void Init(string answer)
    {
        _myAnswer = answer;
        _textMesh.text = _myAnswer;
        
        int random = Random.Range(-360, 360);
        transform.eulerAngles = new Vector3(0, 0, random);
    }

    public string GetAnswer()
    {
        return _myAnswer;
        Destroy(this);
    }
}
