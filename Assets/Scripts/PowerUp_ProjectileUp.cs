using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_ProjectileUp : PowerUp
{
    //Function yang dipanggil untuk memberikan deteksi collider pada power up health up, dalam kasus ini bila power up menyentuh pesawat player, maka support pesawat player akan bertambah
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
