using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EmptyPiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ResourceManager _resourceManager;

    private bool _inCursor=false;
    
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
        _imageCompo = transform.Find("Visual").GetComponent<Image>();
        _imageCompo.sprite = null;
        _pieceType = ResourceType.none;
        _inCursor = false;
        Debug.Log($"초기화 : {_pieceType}");
    }

    public void SettingPiece(ResourceDataSO resourceData)
    {
        _imageCompo.sprite = resourceData.sprite;
        _pieceType = resourceData.type;
    }

    public bool IsEnumEqual()
    {
        return _myType == _pieceType;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!_resourceManager._isSelect) return;
        
        _resourceManager.EnterEmptyPointer(this); // 이거요
        _inCursor = true;
        // EMptyPiece위에 있을때요 네네
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!_inCursor) return;
        
        _resourceManager.ExitEmptyPointer();
        _inCursor = false;
    }
}
