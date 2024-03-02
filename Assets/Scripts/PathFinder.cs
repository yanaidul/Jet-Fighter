using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private WaveConfigSO _waveConfig;
    private List<Transform> _wayPoints;
    private int _wayPointIndex = 0;
    private Vector3 _targetPosition;
    private float _delta;
    private int _targetPathIndex;

    //Function yang di panggil pada saat game dijalankan
    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        _waveConfig = _enemySpawner.GetCurrentWave();
        _wayPoints = _waveConfig.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].position;
    }

    //Function yang di panggil setiap waktu berlangsungnya game
    private void Update()
    {
        FollowPath();
    }

    //Function yang di panggil untuk membuat pesawat musuh bergerak sesuai dengan waypoint nya
    private void FollowPath()
    {
        if (_wayPointIndex < _wayPoints.Count - _targetPathIndex)
        {
            _targetPosition = _wayPoints[_wayPointIndex].position;
            _delta = _waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _delta);
            if (transform.position == _targetPosition)
            {
                _wayPointIndex++;
            }

        }
    }

    //Function yang di panggil untuk mengubah target path index
    public void SetTargetPathIndex(int index)
    {
        _targetPathIndex = index;
    }

    //Function yang di panggil untuk membuat pesawat musuh mengupdate wave confignya dengan current wave dan waypoints sekarang
    public void UpdateToCurrentWave()
    {
        _wayPointIndex = 0;
        _waveConfig = _enemySpawner.GetCurrentWave();
        _wayPoints = _waveConfig.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].position;
    }
}
