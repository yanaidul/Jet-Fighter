using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Anim_UpDownLoop : MonoBehaviour
{
    [SerializeField] private float _targetY = 0.3f;
    [SerializeField] private float _duration = 0.3f;

    private Tweener _myTween;

    private void Start()
    {
        _myTween = transform.DOLocalMoveY(_targetY, _duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }

    private void OnEnable()
    {
        _myTween.Play();
    }

    private void OnDisable()
    {
        _myTween.Pause();
    }
}
