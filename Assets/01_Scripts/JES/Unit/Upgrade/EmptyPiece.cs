using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EmptyPiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ResourceManager _resourceManager;

    private bool _inCursor=false;
    private bool _isEmpty = true;
    [SerializeField] private Image _imageCompo;
    [SerializeField] private Sprite _nullSprite;
    
    [SerializeField] private ResourceType _myType;
    private ResourceType _pieceType = ResourceType.none;
    
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private int _answer;
    private void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _imageCompo.sprite = _nullSprite;
    }

    private void OnDisable()
    {
        Reset();
    }

    public void Reset(bool isUpgrade = false)
    {
        _imageCompo.sprite = _nullSprite;
        
        _isEmpty = true;
        if (_pieceType != ResourceType.none&&!isUpgrade)
        {
            _resourceManager.ResourceCountBack(_pieceType);
        }
        
        _pieceType = ResourceType.none;
        _inputField.gameObject.SetActive(false);
        _inCursor = false;
    }

    public void SettingPiece(ResourceDataSO resourceData)
    {
        _pieceType = resourceData.type;
        _isEmpty = false;

        if (_pieceType == ResourceType.number)
        {
            _inputField.gameObject.SetActive(true);
        }
        else
        {
            _imageCompo.sprite = resourceData.sprite;
        }
    }
    public void InputFieldChage()
    {
        UpgradeManager.Instance.EmptyCheck();
    }
    public bool IsEnumEqual()
    {
        if (_pieceType == ResourceType.number && _myType == ResourceType.number)
        {
            if(int.TryParse(_inputField.text,out int num))
            {
                return num == _answer;
            }
            return false;
        }
        return _myType == _pieceType;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!_resourceManager._isSelect||!_isEmpty) return;
        
        _resourceManager.EnterEmptyPointer(this);
        _inCursor = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!_inCursor) return;
        
        _resourceManager.ExitEmptyPointer();
        _inCursor = false;
    }
}
