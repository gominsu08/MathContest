using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [Header("AttackSetting")] 
    [SerializeField] protected float _range;
    [SerializeField] protected float _attackCoolTime;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;
    
    
    [SerializeField] protected LayerMask _targetLayer;
    
    #region Component
    public DamageCaster DamangeCasterCompo { get;protected set; }
    public Health HealthComp { get;protected set; }
    public AgentMovement MovementComp { get;protected set; }
    #endregion
    protected virtual void Start()
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

    public virtual void Attack()
    {
        //구현해야댐
    }
    
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * _range);
    }

#endif
}
