using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _powerUpSpeed;
    [SerializeField] private float _powerUpLifeTime;
    [SerializeField] protected GameEventNoParam _onPowerUp;

    public void OnEnable()
    {
        StartCoroutine(OnSetInactive());
    }

    public void LaunchPowerUp()
    {
        if (!TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) return;
        rb.velocity = gameObject.transform.right * _powerUpSpeed;
    }

    protected IEnumerator OnSetInactive()
    {
        yield return new WaitForSeconds(_powerUpLifeTime);
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }
}
