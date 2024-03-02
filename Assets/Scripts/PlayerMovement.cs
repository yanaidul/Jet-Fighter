using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _paddingLeft, _paddingRight, _paddingTop, _paddingBottom = 0;
    [SerializeField] private InputReader _inputReader = null;

    private Camera _mainCamera = null;
    private Vector3 _newPos;
    private Vector2 _clampedPos;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        InitBounds();
    }

    //Function yang di panggil setiap waktu berlangsungnya game
    private void Update()
    {
        HandleMovement(Time.deltaTime);
    }

    //Function yang di panggil untuk mendeteksi batas posisi world dari perspektif kamera
    private void InitBounds()
    {
        _mainCamera = Camera.main;
        _minBounds = _mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = _mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    //Function yang di panggil untuk membuat pesawat player tidak dapat keluar kamera
    private void HandleMovement(float deltaTime)
    {
        _newPos = _inputReader.MovementValue * deltaTime * _moveSpeed;
        _clampedPos = new Vector2();
        _clampedPos.x = Mathf.Clamp(transform.position.x + _newPos.x, _minBounds.x + _paddingLeft, _maxBounds.x - _paddingRight);
        _clampedPos.y = Mathf.Clamp(transform.position.y + _newPos.y, _minBounds.y + _paddingBottom, _maxBounds.y - _paddingTop);
        transform.position = _clampedPos;
    }
}
