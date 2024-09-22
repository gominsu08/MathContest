using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [Header("AttackSetting")] 
    [SerializeField] protected int _range;
    [SerializeField] protected float _attackCoolTime;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _cost;
    [SerializeField] protected int _damage;
    
    
    [SerializeField] protected LayerMask _targetLayer;
    
    #region Component
    public DamageCaster DamangeCasterCompo { get;protected set; }
    public Health HealthComp { get;protected set; }
    public AgentMovement MovementComp { get;protected set; }
    #endregion
    private void Start()
    {
        DamangeCasterCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        HealthComp = GetComponent<Health>();
        MovementComp = GetComponent<AgentMovement>();
    }

    public bool TargetDetect()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _range, _targetLayer);

        // 레이가 플레이어를 감지했는지 여부를 불값으로 반환
        return hit.collider != null;
    }
    
    public abstract void Attack();
    
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * _range);
    }

#endif
}
