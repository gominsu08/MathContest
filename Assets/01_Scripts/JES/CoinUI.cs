using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText,levelUpCostTxt,levelText;
    
    
    private void Start()
    {
        CombatManager.Instance.OnCoinChageEvent += HandleCoinChange;
        CombatManager.Instance.OnLevelChangeEvent += HandleLevelChange;
    }

    private void HandleLevelChange(int arg1, int arg2)
    {
        levelUpCostTxt.text = arg1.ToString();
        levelText.text = $"Level.{arg2}";
    }

    private void HandleCoinChange(float arg1, int arg2)
    {
        _coinText.text = $"{Mathf.FloorToInt(arg1)} / {arg2}";
    }
}
