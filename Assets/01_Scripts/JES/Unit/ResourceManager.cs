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
    
    private Dictionary<ResourceType,Sprite> _spriteDic = new Dictionary<ResourceType, Sprite>();

    private void Awake()
    {
        foreach (var data in dataList.dataList)
        {
            Resource resource = Instantiate(_resourcePrefab, transform);
            resource.Initalized(data);
            _spriteDic.Add(data.type,data.sprite);
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isCursor)
        {
            _isSelect = true;
            Piece piece = Instantiate(piecePrefab);
            piece.Initialize(_spriteDic[_keyType]);
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