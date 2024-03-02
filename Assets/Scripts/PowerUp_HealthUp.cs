using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_HealthUp : PowerUp
{

    //Function yang dipanggil untuk memberikan deteksi collider pada power up health up, dalam kasus ini bila power up menyentuh pesawat player, maka darah player akan bertambah
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
