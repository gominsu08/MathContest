using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitUpgrade : MonoBehaviour
{
    private UnitUpgradeData _unitData;//유닛 데이터 저장
    private Image _imageCompo;//이미지 컴포

    [SerializeField]
    private GameObject _panel;//껐다 킬 패널
    [SerializeField] private TextMeshProUGUI _nameText; // 이름 텍스트

    
    public void Initalize(UpgradeManager manager, UnitUpgradeData data)
    {
        _imageCompo = GetComponent<Image>();
        
        _unitData = data;
        _imageCompo.sprite = _unitData.sprite;
        
        manager.OnChangeEvent += HandleChangeEvent;
        _panel.SetActive(manager.index!=_unitData.index);
        
        _nameText.text = _unitData.name;
    }

    private void HandleChangeEvent(int index, bool _isRight)
    {
        _panel.SetActive(index!=_unitData.index);
        
        int xPos = _isRight ? -500 : 500;
        
        transform.DOMoveX( transform.position.x+xPos, 0.75f).SetEase(Ease.OutQuint);
    }
}
