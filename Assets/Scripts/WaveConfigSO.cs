using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config",fileName ="New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private Transform _pathPrefab;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _timeBetweenEnemySpawns = 1f;
    [SerializeField] private float _spawnTimeVariance = 0f;
    [SerializeField] private float _minSpawnTime = 0.2f;

    private float _spawnTime;

    #region Properties
    public float MoveSpeed => _moveSpeed;
    #endregion

    public int GetEnemyCount()
    {
        return _enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return _enemyPrefabs[index];
    }

    public Transform GetStartingWayPoint()
    {
        return _pathPrefab.GetChild(0).transform;
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach(Transform child in _pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public float GetRandomSpawnTime()
    {
        _spawnTime = Random.Range(_timeBetweenEnemySpawns - _spawnTimeVariance,
                                  _timeBetweenEnemySpawns + _spawnTimeVariance);
        Mathf.Clamp(_spawnTime, _minSpawnTime, float.MaxValue);
        return _spawnTime;
    }

}
