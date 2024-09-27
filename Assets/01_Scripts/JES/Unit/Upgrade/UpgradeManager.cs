using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoSingleton<UpgradeManager>
{
    [SerializeField] private List<UnitUpgradeData> _dataList; //데이터 리스트
    [SerializeField] private UnitUpgrade _unitPrefab; // 유닛 칸 프리팹
    
    public float _xPadding; // x좌표 패딩값 - 현재 500
    private float curPadding; // 현재 얼마나 패딩했는지.
    
    [SerializeField] private GameObject _lBtn, _rBtn;//좌우 버튼
    
    public event Action<int, bool> OnChangeEvent; // 인덱스 값이 바뀐 이벤트
    public event Action<int,int> OnLevelUpEvent; // 인덱스 값이 바뀐 이벤트
    public int index = 0; // 현재 선택 인덱스 값

    private bool _isMove = false;
    [Header("Upgrade Menu")] 
    [SerializeField] private GameObject _btnPanel;
    private void Awake()
    {
        foreach (UnitUpgradeData upgradeData in _dataList)
        {
            UnitUpgrade unit = Instantiate(_unitPrefab, transform); //소환

            unit.transform.localPosition = new Vector3(_xPadding * curPadding, 0, 0); //패딩

            unit.Initalize(this, upgradeData); // 유닛 세팅

            curPadding++; // 패딩 값 늘리기
        }

        _lBtn.SetActive(false); // 좌측 버튼 꺼두기
    }

    private void CoStart()
    {
        _isMove = true;
        StartCoroutine("DelayCO");
    }

    private IEnumerator DelayCO()
    {
        yield return new WaitForSeconds(0.8f);
        _isMove = false;
    }

    public void EmptyCheck()
    {
        if (_dataList[index].emptyManager.CheckAnswer())
        {
            _btnPanel.SetActive(false);
        }
        else
        {
            _btnPanel.SetActive(true);
        }
    }
    public void LeftBtnClick()
    {
        if (index > 0&&!_isMove)
        {
            OnChangeEvent?.Invoke(--index, false);
            _rBtn.SetActive(true);
            CoStart();
        }
        
        if(index==0)
            _lBtn.SetActive(false);
    }
    public void RightBtnClick()
    {
        if (index < 5&&!_isMove)
        {
            OnChangeEvent?.Invoke(++index, true);
            _lBtn.SetActive(true);
            CoStart();
        }
        
        if(index==5)
            _rBtn.SetActive(false);
    }

    public void UpgradeBtnClick()
    {
        _dataList[index].emptyManager.ResetPiece(true);
        _btnPanel.SetActive(true);
        _dataList[index].LevelUp();
        OnLevelUpEvent?.Invoke(index, _dataList[index].level);
    }

    public void ResetBtn()
    {
        _dataList[index].emptyManager.ResetPiece();
        _btnPanel.SetActive(true);
    }
}