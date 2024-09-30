using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StageBtn : MonoBehaviour
{
    private int _towerNum;
    private TextMeshPro _text;
    public Transform camPos;

    public Action<int> OnClickEvent;

    public Transform Init(int towerNum)
    {
        _text = transform.Find("Text").GetComponent<TextMeshPro>();
        _text.text = towerNum.ToString();
        _towerNum = towerNum;
        
        camPos = transform.Find("CamPos").GetComponent<Transform>();
        
        return camPos;
    }

    private void OnMouseDown()
    {
        OnClickEvent?.Invoke(_towerNum);
    }
}
