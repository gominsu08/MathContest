using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Tower : MonoBehaviour
{
    [SerializeField] private StageDataSO stageData;
    
    public List<Transform> _towerPoints;
    public StageBtn towerPrefab;
    [SerializeField] private int _towerCount = 5;
    
    public int currentTowerIndex;

    public Action<int> OnTowerClickEvent;
    
    private void Awake()
    {
        currentTowerIndex = 0;
        for (int i = 0; i < _towerCount; i++)
        {
            var sBtnGObj =  Instantiate(towerPrefab.gameObject);
            StageBtn sBtn = sBtnGObj.GetComponent<StageBtn>();
            sBtn.transform.position = new Vector3(sBtn.transform.position.x, sBtn.transform.position.y + (i * 3.67f));
            Transform pos = sBtn.Init(i + 1);
            _towerPoints.Add(pos);
            sBtn.OnClickEvent += HandleclickEvent;
        }
    }

    private void HandleclickEvent(int num)
    {
        if (stageData.stageCount + 1 >= num)
        {
            stageData.CountSet();
            SceneManager.LoadScene("CombatScene");
        }
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
