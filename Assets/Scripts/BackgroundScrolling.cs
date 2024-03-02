using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float _additionalScrollSpeed;
    [SerializeField] private GameObject[] _backgroundComponents;
    [SerializeField] private float[] _eachComponentScrollSpeed;

    private float _offset;

    //Function yang di panggil setiap jeda waktu 0.02 detik selama berlangsungnya game
    private void FixedUpdate()
    {
        //loop untuk menggerakkan semua komponen background  sesuai dengan variable speed diatas (_eachComponentScrollSpeed dan _additionalScrollSpeed)
        for (int i = 0; i < _backgroundComponents.Length; i++)
        {
            if (!_backgroundComponents[i].TryGetComponent<Renderer>(out Renderer renderer)) return;
            _offset = Time.time * (_eachComponentScrollSpeed[i] + _additionalScrollSpeed);
            renderer.material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
        }
    }
}
