using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EscPanel : MonoBehaviour
{
    private List<MainBtnMethod> _btnList;

    public bool _isGameStop;

    private void Awake()
    {
        Time.timeScale = 1;
        _isGameStop = false;
        
        _btnList = new List<MainBtnMethod>();
        foreach (var item in transform)
        {
            if (TryGetComponent(out MainBtnMethod btn))
            {
                _btnList.Add(btn);
                btn.gameObject.SetActive(false);
            }
        }
        
        gameObject.SetActive(false);
        ActiveBtns(false);
    }

    private void ActiveBtns(bool isActive)
    {
        foreach (MainBtnMethod item in _btnList)
        {
            item.gameObject.SetActive(isActive);
        }
    }

    public void SetStopGame()
    {
        Time.timeScale = 0;
        _isGameStop = true;
        
        ActiveBtns(true);
        
        gameObject.SetActive(true);
    }

    public void SetStartGame()
    {
        Time.timeScale = 1;
        _isGameStop = false;
        
        ActiveBtns(false);
        
        gameObject.SetActive(false);
    }

    public void ExitMiniGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}
