using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_HealthUp : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<PlayerHealth>(out PlayerHealth health)) return;
        _onPowerUp.Raise();
        health.Heal(1);
        if (!TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) return;
        rb.velocity = Vector3.zero;
        StopCoroutine(OnSetInactive());
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }
}
