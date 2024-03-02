using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _powerUpSpeed;
    [SerializeField] private float _powerUpLifeTime;
    [SerializeField] protected GameEventNoParam _onPowerUp;

    //Function yang terpanggil pada saat gameobject aktif
    public void OnEnable()
    {
        StartCoroutine(OnSetInactive());
    }

    //Function yang terpanggil untuk membuat power up gerak ke kiri
    public void LaunchPowerUp()
    {
        if (!TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) return;
        rb.velocity = gameObject.transform.right * _powerUpSpeed;
    }

    //Function yang terpanggil untuk membuat power up menjadi nonaktif bila tidak di collect sesuai dengan durasi _powerUpLifeTime
    protected IEnumerator OnSetInactive()
    {
        yield return new WaitForSeconds(_powerUpLifeTime);
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }
}
