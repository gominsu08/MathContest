using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTower : MonoBehaviour
{
    private Health _healthCompo;
    [SerializeField] private StageDataSO _data;
    private void Start()
    {
        _healthCompo = GetComponent<Health>();
        _healthCompo.Initialize(_data.pcTowerHP);
    }
}
