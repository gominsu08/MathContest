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
    
    public bool _isSelect=false;
    private bool _isCursor=false;
    
    private Dictionary<ResourceType,Resource> _spriteDic = new Dictionary<ResourceType, Resource>();

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
                Piece piece = Instantiate(piecePrefab);
                piece.Initialize(_spriteDic[_keyType].resourceData.sprite);
                _spriteDic[_keyType].count.Value--;
            }
        }
        else if (Input.GetMouseButtonUp(0) && _isSelect)
        {
            //조각 놓는 작업
        }
    }

    public void ExitPointer()
    {
        _isCursor = false;
        _keyType = ResourceType.none;
    }
    
    public void EnterPointer(ResourceType keyType)
    {
        _isCursor = true;
        _keyType = keyType;
    }
}