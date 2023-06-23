using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] _enemySprite;
    private int _randomizedIndex;

    private void OnEnable()
    {
        _randomizedIndex = Random.Range(0, _enemySprite.Length);
        if (!TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)) return;
        spriteRenderer.sprite = _enemySprite[_randomizedIndex];
    }
}
