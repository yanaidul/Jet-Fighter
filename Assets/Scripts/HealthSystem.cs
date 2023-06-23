using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _maxHealth = 100, _currentHealth,_initHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
            }

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            
        }
    }

    public virtual void OnEnable()
    {
        CurrentHealth = _initHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}