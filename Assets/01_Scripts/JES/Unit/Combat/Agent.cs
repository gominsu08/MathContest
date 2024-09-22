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
    [SerializeField] protected float knockPower;



    private float _lastAttackTime;
    [SerializeField] protected LayerMask _targetLayer;

    public bool AnimationEndTrigger { get; set; } = false;
    private bool _isMove = false;
    
    #region Component
    public DamageCaster DamangeCasterCompo { get;protected set; }
    public Health HealthComp { get;protected set; }
    public AgentMovement MovementComp { get;protected set; }
    
    public UnitAnimator AnimatorComp { get;protected set; }
    #endregion
    protected virtual void Start()
    {
        DamangeCasterCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        HealthComp = GetComponent<Health>();
        MovementComp = GetComponent<AgentMovement>();
        AnimatorComp = transform.Find("Visual").GetComponent<UnitAnimator>();
        
        AnimatorComp.Initalize(this);
        MovementComp.IniaLize(_speed);
        MovementSet(true);
    }

    private void FixedUpdate()
    {
        if(AnimationEndTrigger) return;

        bool spotTarget = TargetDetect();
        if (spotTarget)
        {
            
            if (_lastAttackTime + _attackCoolTime < Time.time)
            {
                AttackStart();
            }
            else
            {
                AnimatorComp.IdleAniSet();
            }
        }
        else if(!spotTarget&&!_isMove&&_lastAttackTime + _attackCoolTime < Time.time)
        {
            MovingSet();
        }
    }

    private void MovingSet()
    {
        MovementSet(true);
        AnimatorComp.MoveAniSet();
    }

    private void AttackStart()
    {
        MovementSet(false);
        AnimationEndTrigger = true;
        AnimatorComp.AttackAniSet();
    }

    private void MovementSet(bool isMove)
    {
        MovementComp.MoveSet(isMove);
        _isMove = isMove;
    }

    private bool TargetDetect()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _range, _targetLayer);

        // 레이가 플레이어를 감지했는지 여부를 불값으로 반환
        return hit.collider != null;
    }
    public void AniEndTrigger()
    {
        AnimationEndTrigger = false;
        _lastAttackTime = Time.time;
    }
    public virtual void Attack()
    {
        //구현
    }
    
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * _range);
    }

    #endif
    
}
