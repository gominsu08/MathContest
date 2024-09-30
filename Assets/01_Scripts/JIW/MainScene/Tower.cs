using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Tower : MonoBehaviour
{
    public List<Transform> _towerPoints;
    
    public int currentTowerIndex;

    public Action<int> OnTowerClickEvent;
    
    private void Awake()
    {
        currentTowerIndex = 0;
    }

    public void OnClickUp()
    {
        if (currentTowerIndex >= _towerPoints.Count - 1) return;
        
        currentTowerIndex++;
        OnTowerClickEvent?.Invoke(currentTowerIndex);
    }

    public void OnClickDown()
    {
        if (currentTowerIndex <= 0) return;
        
        currentTowerIndex--;
        OnTowerClickEvent?.Invoke(currentTowerIndex);
    }
}
