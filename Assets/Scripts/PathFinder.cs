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

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Start()
    {
        _waveConfig = _enemySpawner.GetCurrentWave();
        _wayPoints = _waveConfig.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].position;
    }

    private void Update()
    {
        FollowPath();
    }

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

    public void SetTargetPathIndex(int index)
    {
        _targetPathIndex = index;
    }

    public void UpdateToCurrentWave()
    {
        _wayPointIndex = 0;
        _waveConfig = _enemySpawner.GetCurrentWave();
        _wayPoints = _waveConfig.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].position;
    }
}
