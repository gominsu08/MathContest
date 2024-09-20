using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EmptyPiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ResourceManager _resourceManager;

    private bool _inCursor=false;
    private bool _isEmpty = true;
    private Image _imageCompo;

    [SerializeField] private ResourceType _myType;
    private ResourceType _pieceType = ResourceType.none;
    
    private void Start()
    {
        _resourceManager = ResourceManager.Instance;
        
        _imageCompo = transform.Find("Visual").GetComponent<Image>();
    }

    private void OnDisable()
    {
        Reset();
    }

    public void Reset(bool isUpgrade = false)
    {
        _imageCompo = transform.Find("Visual").GetComponent<Image>();
        _imageCompo.sprite = null;
        _isEmpty = true;
        if (_pieceType != ResourceType.none&&!isUpgrade)
        {
            _resourceManager.ResourceCountBack(_pieceType);
        }
        
        _pieceType = ResourceType.none;
        _inCursor = false;
    }

    public void SettingPiece(ResourceDataSO resourceData)
    {
        _imageCompo.sprite = resourceData.sprite;
        _pieceType = resourceData.type;
        _isEmpty = false;
    }

    public bool IsEnumEqual()
    {
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
