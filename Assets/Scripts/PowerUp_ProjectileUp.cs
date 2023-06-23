using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_ProjectileUp : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<PowerUpManager>(out PowerUpManager powerup)) return;
        _onPowerUp.Raise();
        powerup.NumberOfActivatedSupport++;
        if (!TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) return;
        rb.velocity = Vector3.zero;
        StopCoroutine(OnSetInactive());
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }
}
