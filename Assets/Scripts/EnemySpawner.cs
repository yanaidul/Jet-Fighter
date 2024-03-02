using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> _waveConfigs;
    [SerializeField] private GameEvent _onSetCurrentEnemyWaveCount;
    private WaveConfigSO _currentWave;
    private int _currentWaveIndex = 0;

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    void Start()
    {
        //StartCoroutine(SpawnEnemyWaves());
        StartCoroutine(SpawnWave());
    }

    //Function yang dipanggil untuk mengreturn WaveConfig yang digunakan (waveconfig berbeda-beda setiap wavenya)
    public WaveConfigSO GetCurrentWave()
    {
        return _currentWave;
    }

    //Function yang dipanggil untuk spawn wave of enemies
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

    //Function yang dipanggil untuk spawn wave selanjutnya (bila enemy wave sekarang sudah habis)
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

    //Function untuk membuat musuh bergerak ke target yang sudah di tentukan
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

    //Function untuk membuat musuh mengupdate path findernya (biar tidak sama terus)
    private void UpdateEnemyWave(GameObject enemy)
    {
        if (!enemy.TryGetComponent<PathFinder>(out PathFinder enemyPath)) return;
        enemyPath.UpdateToCurrentWave();
    }

}
