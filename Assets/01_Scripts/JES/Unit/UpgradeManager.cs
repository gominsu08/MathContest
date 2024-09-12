using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoSingleton<UpgradeManager>
{
    private List<UnitUpgradeData> _dataList;
    [SerializeField] private UnitUpgrade _unitPrefab;

    public event Action<int, bool> OnChangeEvent;
    public int index = 0;
    
    private void Awake()
    {
        foreach (UnitUpgradeData upgradeData in _dataList)
        {
            UnitUpgrade unit = Instantiate(_unitPrefab, transform);
            
            //패딩 해야함
            unit.Initalize(this, upgradeData);
            
            
        }
    }
}