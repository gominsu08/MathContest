using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour, IPoolable
{
    [Header("AttackSetting")] 
    [SerializeField] protected float _range;
    [SerializeField] protected float _attackCoolTime;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;


    protected Transform _targetTrm;
    private float _lastAttackTime;
    [SerializeField] protected LayerMask _targetLayer;

    public bool AnimationEndTrigger { get; set; } = false;
    private bool _isMove = false;
    
    private bool _isDead = false;
    protected int _pcLayer;
    protected int _deadLayer;
    
    [SerializeField] private UnitDataSO _enemyData;
    #region Component
    public DamageCaster DamangeCasterCompo { get;protected set; }
    public Health HealthComp { get;protected set; }
    public AgentMovement MovementComp { get;protected set; }
    
    public UnitAnimator AnimatorComp { get;protected set; }
    #endregion
    protected virtual void Awake()
    {
        DamangeCasterCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        HealthComp = GetComponent<Health>();
        MovementComp = GetComponent<AgentMovement>();
        AnimatorComp = transform.Find("Visual").GetComponent<UnitAnimator>();
        
        AnimatorComp.Initalize(this);
        MovementComp.IniaLize(_speed);
        MovementSet(true);
        _deadLayer = LayerMask.NameToLayer("DeadBody");

        _pcLayer = gameObject.layer;
        
        if (_enemyData != null)
        {
            HealthComp.Initialize(_enemyData.health);
            _damage = _enemyData.damage;
        }
    }

    private void FixedUpdate()
    {
        if (_isDead && !AnimationEndTrigger)
        {
            DeadAniEnd();
        }
        else if (AnimationEndTrigger || _isDead)
        {
            return;
        }
        Collider2D spotTarget = TargetDetect();
        if (spotTarget!=null)
        {
            _targetTrm = spotTarget.transform;
            if (_lastAttackTime + _attackCoolTime < Time.time)
            {
                AttackStart();
            }
            else
            {
                AnimatorComp.IdleAniSet();
            }
        }
        else if(spotTarget==null&&!_isMove&&_lastAttackTime + _attackCoolTime < Time.time)
        {
            MovingSet();
        }
    }

    public void DeadEnter()
    {
        MovementSet(false);
        gameObject.layer = _deadLayer;
        _isDead = true;
        AnimatorComp.DeadAniSet();
        AnimationEndTrigger = true;
    }

    public void DeadAniEnd()
    {
        PoolManager.Instance.Push(this);
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

    private Collider2D TargetDetect()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _range, _targetLayer);

        // 레이가 플레이어를 감지했는지 여부를 불값으로 반환
        return hit.collider != null? hit.collider : null;
    }
    public void AniEndTrigger()
    {
        AnimatorComp.IdleAniSet();
        AnimationEndTrigger = false;
        _lastAttackTime = Time.time;
    }
    public virtual void Attack()
    {
        DamangeCasterCompo.CastDamage(_damage);
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * _range);
    }

    #endif

    [SerializeField] private string _poolName;
    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    public void ResetItem()
    {
        _lastAttackTime = 0;
        _isDead = false;
        gameObject.layer = _pcLayer;
    }
}
