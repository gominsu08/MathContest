using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Memo : MonoBehaviour
{
    private NotifyValue<Vector3> mouseNotify;
    private LineRenderer _currentline;
    [HideInInspector] public List<LineRenderer> lineList;
    private List<Vector3> _memoList;
    private Vector3 _memoMaxSize;
    private Vector3 _memoMinSize;
    [SerializeField] private GameObject _panPrefab;
    [SerializeField] private Gradient _panColor;

    private void Awake()
    {
        mouseNotify = new NotifyValue<Vector3>();
        lineList = new List<LineRenderer>();
        mouseNotify.OnValueChanged += HandleOnDrawLine;
        _memoList = new List<Vector3>();
        
        Bounds bounds = GetComponent<Collider2D>().bounds;
        
        _memoMaxSize = bounds.max;
        _memoMinSize = bounds.min;
    }

    private void OnDisable()
    {
        mouseNotify.OnValueChanged -= HandleOnDrawLine;
    }

    private void OnMouseDown()
    {
        GameObject obj = Instantiate(_panPrefab, transform);
        
        _currentline = obj.GetComponent<LineRenderer>();
        _currentline.colorGradient = _panColor;
        lineList.Add(_currentline);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        mouseNotify.Value = new Vector3(mousePos.x, mousePos.y);
    }

    private void OnMouseUp()
    {
        _memoList.Clear();
    }

    private void HandleOnDrawLine(Vector3 prev, Vector3 next)
    {
        float posX = Mathf.Clamp(next.x, _memoMinSize.x, _memoMaxSize.x);
        float posY = Mathf.Clamp(next.y, _memoMinSize.y, _memoMaxSize.y);
        
        Vector3 pos = new Vector3(posX, posY);
        
        _memoList.Add(pos);
        _currentline.positionCount = _memoList.Count;
        _currentline.SetPositions(_memoList.ToArray());
    }
}
