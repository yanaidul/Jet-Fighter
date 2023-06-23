using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float _additionalScrollSpeed;
    [SerializeField] private GameObject[] _backgroundComponents;
    [SerializeField] private float[] _eachComponentScrollSpeed;

    private float _offset;


    private void FixedUpdate()
    {
        for (int i = 0; i < _backgroundComponents.Length; i++)
        {
            if (!_backgroundComponents[i].TryGetComponent<Renderer>(out Renderer renderer)) return;
            _offset = Time.time * (_eachComponentScrollSpeed[i] + _additionalScrollSpeed);
            renderer.material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
        }
    }
}
