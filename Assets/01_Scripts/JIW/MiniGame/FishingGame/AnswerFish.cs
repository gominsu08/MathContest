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
    public Collider2D _collider;

    private void Awake()
    {
        _textMesh = transform.Find("Text").GetComponent<TextMeshPro>();
        _collider = transform.GetComponent<Collider2D>();
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
        Destroy(this.gameObject);
        return _myAnswer;
    }
}
