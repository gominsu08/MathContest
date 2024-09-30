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

    public void Initialize(int health)
    {
        _maxHealth = health;
        ResetHealth();
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        OnHitEvent?.Invoke();

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
