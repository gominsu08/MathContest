using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitUpgrade : MonoBehaviour
{
    private UnitUpgradeData _unitData;//유닛 데이터 저장
    private Image _imageCompo;//이미지 컴포

    [SerializeField] private GameObject _panel;//껐다 킬 패널
    [SerializeField] private TextMeshProUGUI _nameText; // 이름 텍스트

    private float _paddingValue; // 패딩 값

    private bool _isLimit;
    
    private EmptyPieceManager _emptyPieceManager;
    public void Initalize(UpgradeManager manager, UnitUpgradeData data)
    {
        _imageCompo = GetComponent<Image>();
        
        _unitData = data; // 데이터 설정
        _imageCompo.sprite = _unitData.sprite; // 이미지 데이터의 스프라이트로
        _nameText.text = $"Lv.{_unitData.level} {_unitData.name}"; // 텍스트 이름으로 설정
        
        manager.OnChangeEvent += HandleChangeEvent; // 이벤트 구독
        manager.OnLevelUpEvent += HandleLevelUpEvent;
        _panel.SetActive(manager.index!=_unitData.index); // 패널 인덱스에 맞춰 끄고키기
        
        _paddingValue = manager._xPadding; // 패딩 설정

        _isLimit = _unitData.level == 50;
        
        _emptyPieceManager = Instantiate(_unitData.emptyManagerPrefab, transform.parent.parent);
        _emptyPieceManager.gameObject.SetActive(manager.index==_unitData.index);
        _emptyPieceManager.Initalize(_isLimit);
        _unitData.emptyManager = _emptyPieceManager;
    }

    private void HandleLevelUpEvent(int arg1, int arg2)
    {
        if (_unitData.index == arg1)
        {
            _nameText.text = $"Lv.{arg2} {_unitData.name}";
        }
    }

    private void HandleChangeEvent(int index, bool _isRight) // 인덱스 값이 바뀔때마다 실행될 함수
    {
        _panel.SetActive(index!=_unitData.index); // 패널 인덱스에 맞춰 끄고 키기
        _emptyPieceManager.gameObject.SetActive(index==_unitData.index);
        
        float xPos = _isRight ? -_paddingValue : _paddingValue; // 오른쪽인지 아닌지에 따라 좌표 설정
        
        transform.DOMoveX( transform.position.x+xPos, 0.75f).SetEase(Ease.OutQuint); // 이후 좌표에 맞게 이동
    }
}
