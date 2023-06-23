using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> _waveConfigs;
    [SerializeField] private int _totalStageEnemies;
    [SerializeField] private int _currentWaveEnemy;
    [SerializeField] private GameEventNoParam _onSpawnNextWave;
    [SerializeField] private GameEventNoParam _onWin;

    private void Start()
    {
        foreach (var wave in _waveConfigs)
        {
            _totalStageEnemies += wave.GetEnemyCount();
        }
    }

    public void OnSetCurrentWaveEnemyCount(Component sender, object data)
    {
        if (data is int)
        {
            int amount = (int)data;
            _currentWaveEnemy = amount;
        }

    }

    public void OnEnemyDefeated()
    {
        _totalStageEnemies--;
        if (_totalStageEnemies <= 0) _onWin.Raise();
        _currentWaveEnemy--;
        if (_currentWaveEnemy <= 0) _onSpawnNextWave.Raise();
    }
}
