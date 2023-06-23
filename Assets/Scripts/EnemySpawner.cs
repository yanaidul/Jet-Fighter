using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> _waveConfigs;
    [SerializeField] private GameEvent _onSetCurrentEnemyWaveCount;
    private WaveConfigSO _currentWave;
    private int _currentWaveIndex = 0;

    void Start()
    {
        //StartCoroutine(SpawnEnemyWaves());
        StartCoroutine(SpawnWave());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return _currentWave;
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(0.5f);
        _currentWave = _waveConfigs[_currentWaveIndex];
        _onSetCurrentEnemyWaveCount.Raise(this, _currentWave.GetEnemyCount());
        for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
        {
            GameObject enemy = ObjectPool.Instance.GetObjectFromPool(_currentWave.GetEnemyPrefab(i));
            UpdateEnemyWave(enemy);
            enemy.transform.position = _currentWave.GetStartingWayPoint().position;
            enemy.transform.rotation = Quaternion.identity;

            AssignEnemyTargetPathIndex(enemy, _currentWave, i);
            yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
        }
        _currentWaveIndex++;

    }

    public void SpawnNextWave()
    {
        if(_currentWaveIndex < _waveConfigs.Count)
        {
            StartCoroutine(SpawnWave());
        }
        else
        {
            Debug.LogWarning("There's no wave anymore");
        }
        
    }

    private void AssignEnemyTargetPathIndex(GameObject enemy, WaveConfigSO wave, int index)
    {
        if(wave.GetEnemyCount() < wave.GetWayPoints().Count)
        {
            if (!enemy.TryGetComponent<PathFinder>(out PathFinder enemyPath)) return;
            enemyPath.SetTargetPathIndex(index);
        }
        else
        {
            Debug.LogError("Waypoints not enough to assign every enemy prefabs index");
        }
        
    }

    private void UpdateEnemyWave(GameObject enemy)
    {
        if (!enemy.TryGetComponent<PathFinder>(out PathFinder enemyPath)) return;
        enemyPath.UpdateToCurrentWave();
    }

    //IEnumerator SpawnEnemyWaves()
    //{
    //    foreach (WaveConfigSO wave in _waveConfigs)
    //    {
    //        _currentWave = wave;

    //        for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
    //        {
    //            GameObject enemy = ObjectPool.Instance.GetObjectFromPool(_currentWave.GetEnemyPrefab(i));
    //            enemy.transform.position = _currentWave.GetStartingWayPoint().position;
    //            enemy.transform.rotation = Quaternion.identity;

    //            AssignEnemyTargetPathIndex(enemy, wave, i);
    //            yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
    //        }
    //        yield return new WaitForSeconds(_timeBetweenWaves);
    //    }

    //}
}
