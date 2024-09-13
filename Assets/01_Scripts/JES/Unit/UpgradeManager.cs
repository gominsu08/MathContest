using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeManager : MonoSingleton<UpgradeManager>
{
    [SerializeField]
    private List<UnitUpgradeData> _dataList;
    [SerializeField] private UnitUpgrade _unitPrefab;

    [SerializeField] private float _xPadding;
    private float curPadding;


    [SerializeField] private GameObject _lBtn, _rBtn;//좌우 버튼
    
    
    public event Action<int, bool> OnChangeEvent;
    public int index = 0;
    
    private void Awake()
    {
        foreach (UnitUpgradeData upgradeData in _dataList)
        {
            UnitUpgrade unit = Instantiate(_unitPrefab, transform); //소환

            unit.transform.localPosition = new Vector3(_xPadding * curPadding, 0, 0); //패딩

            unit.Initalize(this, upgradeData);

            curPadding++;

        }

        _lBtn.SetActive(false);
    }

    public void LeftBtnClick()
    {
        if (index > 0)
        {
            OnChangeEvent?.Invoke(--index, false);
            _rBtn.SetActive(true);
        }
        
        if(index==0)
            _lBtn.SetActive(false);
    }
    public void RightBtnClick()
    {
        if (index < 5)
        {
            OnChangeEvent?.Invoke(++index, true);
            _lBtn.SetActive(true);
        }
        
        if(index==5)
            _rBtn.SetActive(false);
    }
}