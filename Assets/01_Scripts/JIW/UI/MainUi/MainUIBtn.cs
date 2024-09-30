using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIBtn : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] private Color _enterColor;

    private Color _color;

    private Image _btnImage;

    private void Awake()
    {
        _color = Color.white;
        _btnImage = GetComponent<Image>();
    }

    public void OnClickBtn()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void OnEnter()
    {
        _btnImage.DOColor(_enterColor, 0.25f);
    }

    public void OnExit()
    {
        _btnImage.DOColor(_color, 0.25f);
    }
}
