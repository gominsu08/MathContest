using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 재료 총괄 매니저
/// </summary>
public class ResourceManager : MonoSingleton<ResourceManager>
{
    [SerializeField] private ResourceSOList dataList;
    [SerializeField] private Resource _resourcePrefab;
    [SerializeField] private Piece piecePrefab;
    
    private ResourceType _keyType;
    
    private bool _isCursor=false;
    public bool _isSelect=false;
    
    private Dictionary<ResourceType,Resource> _spriteDic = new Dictionary<ResourceType, Resource>();

    private bool _inCurEmpty=false; // 커서가 빈 공간에 있나
    private EmptyPiece _selectedPiece; //선택된 빈 공간
    private Piece _curPiece;
    private void Awake()
    {
        foreach (var data in dataList.dataList)
        {
            Resource resource = Instantiate(_resourcePrefab, transform);
            resource.Initalized(data);
            _spriteDic.Add(data.type,resource);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isCursor)
        {
            if (_spriteDic[_keyType].count.Value > 0) // 개수가 0개 초과인지
            {
                _isSelect = true; // 선택됨
                _curPiece = Instantiate(piecePrefab);
                _curPiece.Initialize(_spriteDic[_keyType].resourceData.sprite);
                _spriteDic[_keyType].count.Value--;
            }
        }
        else if (Input.GetMouseButtonUp(0) && _isSelect)
        {
            if (_inCurEmpty)
            {
                _selectedPiece.SettingPiece(_spriteDic[_keyType].resourceData);
                UpgradeManager.Instance.EmptyCheck();
                Destroy(_curPiece.gameObject);
                _isSelect=false;
                ExitPointer();
                //그 커서가 빈공간에 올라가있을때 
                //아 아니지 그 
            }
        }
    }
    public void ExitPointer()
    {
        if(_isSelect) return;//d
        
        _isCursor = false;
        _keyType = ResourceType.none;
    }
    public void EnterPointer(ResourceType keyType)
    {
        if(_isSelect) return; //d
        
        _isCursor = true;
        _keyType = keyType;
    }

    public void EnterEmptyPointer(EmptyPiece piece)
    {
        _selectedPiece = piece; // 여기에서 커서가 올라가있는 빈 piece 넣어줍니다
        _inCurEmpty = true;
    }
    public void ExitEmptyPointer()
    {
        _selectedPiece = null;
        _inCurEmpty = false;
    }
}