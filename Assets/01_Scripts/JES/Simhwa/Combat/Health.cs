using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnHitEvent;
    public UnityEvent OnDeadEvent;

    [SerializeField] private int _maxHealth = 150;

    private int _currentHealth;
    private Agent _owner;

    public void Initialize(Agent owner,bool isPC = false,int health=0)
    {
        _owner = owner;
        if(isPC)
            _maxHealth = health;
        ResetHealth();
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount, Vector2 normal, Vector2 point, float knockbackPower)
    {
        _currentHealth -= amount;
        OnHitEvent?.Invoke();
        //normal과 point, 넉백 등은 차후에 여기서 사용합니다.

        if(knockbackPower > 0)

        if(_currentHealth <= 0)
        {
            OnDeadEvent?.Invoke();
        }
    }

    public float GetNormalizeHealth()
    {
        return _currentHealth/(float)_maxHealth;
    }
}
