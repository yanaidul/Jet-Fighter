using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem,IDamageable
{
    [SerializeField] private GameEvent _onChangeEnemyHealth;
    [SerializeField] private GameEventNoParam _onEnemyDefeated;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        //_onChangeEnemyHealth.Raise(this, CurrentHealth);
        if (CurrentHealth <= 0)
        {
            _onEnemyDefeated.Raise();
            gameObject.SetActive(false);
        }

    }
}
