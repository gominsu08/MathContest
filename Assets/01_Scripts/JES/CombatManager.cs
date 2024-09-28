using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoSingleton<CombatManager>
{
    private float _coin = 0;
    private int _maxCoin = 300;
    private float _coinSec=4.3f;
    public event Action<float,int> OnCoinChageEvent; //코인과 맥스 코인 바뀌었을때 할거
    public event Action<int,int> OnLevelChangeEvent; 

    [SerializeField] private CombatUnitData _unitPrefab;
    [SerializeField] private List<UnitUpgradeData> _dataList; //데이터 리스트
    [SerializeField] private Transform _towerTrm;
    [SerializeField] private List<CoinLevelData> _coinList;
    private int _level = 0;
    
    public bool GameEnd = false;
    private void Awake()
    {
        foreach (UnitUpgradeData data in _dataList)
        {
            Instantiate(_unitPrefab, transform).Initialize(data,this,_towerTrm.position);
        }
        OnLevelChangeEvent?.Invoke(_coinList[_level].cost,_level);
    }

    private void Start()
    {
        OnLevelChangeEvent?.Invoke(_coinList[_level].cost,_level);
    }

    private void Update()
    {
        if(GameEnd) return;
        CoinUpdate();
    }
    private void CoinUpdate()
    {
        if(_coin >= _maxCoin) return;
        _coin += _coinSec*Time.deltaTime;
        
        OnCoinChageEvent?.Invoke(_coin,_maxCoin);
    } //코인이 증가하는 함수
    public bool CoinCheck(float cost)
    {
        if (_coin >= cost)
        {
            _coin -= cost;
            return true;
        }
        return false;
    }

    public void CoinLevelUp()
    {
        if(GameEnd) return;
        if(_coinList[_level].cost==0) return;
        if (CoinCheck(_coinList[_level].cost))
        {
            _level++;
            _maxCoin = _coinList[_level]._maxCoin;
            _coinSec = _coinList[_level]._coinSec;
            OnLevelChangeEvent?.Invoke(_coinList[_level].cost,_level);
        }
    }
}
