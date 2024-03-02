using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Anim_UpDownLoop : MonoBehaviour
{
    [SerializeField] private float _targetY = 0.3f;
    [SerializeField] private float _duration = 0.3f;

    private Tweener _myTween;

    //Function yang terpanggil bila game dimulai
    private void Start()
    {
        //Menyimpan animasi tween ke variable _myTween, yang dimana animasi ini memiliki parameter targetY,durasi,ease in out sine, infinite (-1) loop yoyo
        _myTween = transform.DOLocalMoveY(_targetY, _duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }

    //Function yang terpanggil pada saat gameobject aktif
    private void OnEnable()
    {
        //Menjalankan animasi _myTween
        _myTween.Play();
    }

    //Function yang terpanggil pada saat gameobject tidak aktif
    private void OnDisable()
    {
        //Pause animasi _myTween
        _myTween.Pause();
    }
}
