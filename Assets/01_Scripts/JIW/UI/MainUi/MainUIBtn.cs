using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIBtn : MonoBehaviour
{
    [SerializeField] private string _sceneNeme;
    [SerializeField] private Color _enterColor;

    [SerializeField] private RectTransform _miniGameChoiseBtn;

    public Tower tower;

    private Color _color;

    private Image _btnImage;

    private bool isTrigger = true;

    private void Awake()
    {
        _color = Color.white;
        _btnImage = GetComponent<Image>();
    }

    public void OnPanelSizeMing()
    {
        _miniGameChoiseBtn.gameObject.SetActive(isTrigger);
        tower.ColliderActive(!isTrigger);

        isTrigger = !isTrigger;
    }

    public void OnClickBtn()
    {
        SceneManager.LoadScene(_sceneNeme);
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
