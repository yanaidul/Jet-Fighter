using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitVFX : MonoBehaviour
{
    [SerializeField] float _duration;

    private void OnEnable()
    {
        StartCoroutine(VFXDuration());
    }

    IEnumerator VFXDuration()
    {
        yield return new WaitForSeconds(_duration);
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }
}
