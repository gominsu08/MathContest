using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoSingleton<UpgradeManager>
{
    [SerializeField] private List<UnitUpgradeData> _dataList; //데이터 리스트
    [SerializeField] private UnitUpgrade _unitPrefab; // 유닛 칸 프리팹

    public float _xPadding; // x좌표 패딩값 - 현재 500
    private float curPadding; // 현재 얼마나 패딩했는지.
    
    [SerializeField] private GameObject _lBtn, _rBtn;//좌우 버튼
    
    public event Action<int, bool> OnChangeEvent; // 인덱스 값이 바뀐 이벤트
    public int index = 0; // 현재 선택 인덱스 값
    
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


    public void EmptyCheck()
    {
        if (_dataList[index].emptyManager.CheckAnswer())
        {
            //성공처리
            Debug.Log("성공");
        }
        else
        {
            Debug.Log("실패");
        }
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