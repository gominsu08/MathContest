using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EscCanvers : MonoBehaviour
{
    private EscPanel _escPanel;

    private void Awake()
    {
        _escPanel = transform.GetComponentInChildren<EscPanel>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_escPanel._isGameStop)
            {
                _escPanel.SetStartGame();
            }
            else
            {
                _escPanel.SetStopGame();
            }
        }
    }
}
