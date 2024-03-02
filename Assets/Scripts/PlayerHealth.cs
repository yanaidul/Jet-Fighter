using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem, IDamageable, IHealable
{
    [SerializeField] private GameEvent _onChangePlayerHealth;
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [SerializeField] private GameEventNoParam _onHitPlayer;
    [SerializeField] private GameEventNoParam _onGameOver;

    private void Start()
    {
        CurrentHealth = _playerData.TotalHealth;
        _onChangePlayerHealth.Raise(this, CurrentHealth);
    }

    //Function yang dipanngil untuk membuat darah player berkurang
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _onHitPlayer.Raise();
        _onChangePlayerHealth.Raise(this,CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    //Function yang dipanngil untuk reset data dan menampilkan game over bila player mati
    private void Death()
    {
        gameObject.SetActive(false);
        _playerData.ResetData();
        _onGameOver.Raise();
    }

    //Function yang dipanggil untuk menambahkan darah player
    public void Heal(int amount)
    {
        CurrentHealth += amount;
        _onChangePlayerHealth.Raise(this, CurrentHealth);
    }

    //Function yang dipanggil untuk menyimpan darah player ke player data (untuk dibawa ke scene selanjutnya)
    public void SaveHealthData()
    {
        _playerData.TotalHealth = CurrentHealth;
    }
}
