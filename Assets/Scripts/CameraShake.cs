using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float _shakeDuration = 1f;
    [SerializeField] float _shakeMagnitude = 0.5f;

    private Vector3 _initialPos;
    private float _elapsedTime;
    private IEnumerator _shake;

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        _initialPos = transform.position;
    }

    //Function untuk memplay camera shake
    public void Play()
    {
        _shake = Shake();
        StartCoroutine(_shake);
    }

    //Function untuk menstop camera shake
    public void StopShake()
    {
        if(_shake != null) StopCoroutine(_shake);
        transform.position = _initialPos;
    }

    //Function untuk membuat efek camera shake
    IEnumerator Shake()
    {
        _elapsedTime = 0;
        while (_elapsedTime < _shakeDuration)
        {
            transform.position = _initialPos + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
            _elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = _initialPos;
    }
}
