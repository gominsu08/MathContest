using System;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    private readonly int moveHash = Animator.StringToHash("Move");
    private readonly int attackHash = Animator.StringToHash("Attack");
    private readonly int idleHash = Animator.StringToHash("Idle");
    private readonly int deadHash = Animator.StringToHash("Dead");
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Agent _agent;
    public void Initalize(Agent agent)
    {
        _agent = agent;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        MoveAniSet();
    }

    public void MoveAniSet()
    {
        _animator.SetBool(attackHash, false);
        _animator.SetBool(moveHash, true);
        _animator.SetBool(idleHash, false);
    }

    public void AttackAniSet()
    {
        _animator.SetBool(attackHash, true);
        _animator.SetBool(moveHash, false);
        _animator.SetBool(idleHash, false);
    }

    public void IdleAniSet()
    {
        _animator.SetBool(idleHash, true);
        _animator.SetBool(attackHash, false);
        _animator.SetBool(moveHash, false);
    }
    private void AttackTrigger()
    {
        _agent.Attack();
    }

    private void AnimationEndTrigger()
    {
        _agent.AniEndTrigger();
    }

    public void DeadAniSet()
    {
        _animator.SetTrigger(deadHash);
    }
}