using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUnit : Agent
{
    [SerializeField] private UnitDataSO _unitData;
    
    protected override void Start()
    {
        base.Start();
        
        transform.rotation = Quaternion.Euler(0, 180, 0);
        
        _damage = _unitData.damage;
        _speed = _unitData.speed;
        HealthComp.Initialize(this,true,_unitData.health);
        MovementComp.IniaLize(_speed);
    }
}
