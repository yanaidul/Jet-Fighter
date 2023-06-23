using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private GameObject _vfxExplosion;
    [SerializeField] private float _bulletSpeed;

    #region Properties
    public float BulletSpeed => _bulletSpeed;
    #endregion

    private void OnEnable()
    {
        StartCoroutine(OnSetInactive());
    }

    public void LaunchBullet()
    {
        if (!TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) return;
        rb.velocity = gameObject.transform.right * _bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<HealthSystem>(out HealthSystem health)) return;
        health.TakeDamage(_bulletDamage);
        TriggerVFXExplosion();
        if (!TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) return;
        rb.velocity = Vector3.zero;
        StopCoroutine(OnSetInactive());
        ObjectPool.Instance.ReturnObjectToPool(gameObject);

        if (!collision.TryGetComponent<PowerUpManager>(out PowerUpManager powerup)) return;
        powerup.NumberOfActivatedSupport--;
    }

    private void TriggerVFXExplosion()
    {
        GameObject explosion = ObjectPool.Instance.GetObjectFromPool(_vfxExplosion);
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
    }

    IEnumerator OnSetInactive()
    {
        yield return new WaitForSeconds(_bulletLifeTime);
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }

}
