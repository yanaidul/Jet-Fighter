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

    //Function yang terpanggil pada saat gameobject aktif
    public virtual void OnEnable()
    {
        CurrentHealth = _initHealth;
    }

    //Function yang dipanngil untuk membuat darah musuh berkurang
    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}