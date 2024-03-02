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

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        foreach (var wave in _waveConfigs)
        {
            _totalStageEnemies += wave.GetEnemyCount();
        }
    }

    //Function yang dipanggil untuk menghitung jumlah musuh dalam 1 wave
    public void OnSetCurrentWaveEnemyCount(Component sender, object data)
    {
        if (data is int)
        {
            int amount = (int)data;
            _currentWaveEnemy = amount;
        }

    }

    //Function yang dipanggil setiap musuh dikalahkan sehingga mengurangi jumlah variable _totalStageEnemies (total musuh dalam 1 stage), bila _totalStageEnemies sudah 0 maka win screen akan ke trigger, dan bila _currentWaveEnemy
    //0 maka lanjut ke wave selanjutnya (bila masih ada wave di stage itu)
    public void OnEnemyDefeated()
    {
        _totalStageEnemies--;
        if (_totalStageEnemies <= 0) _onWin.Raise();
        _currentWaveEnemy--;
        if (_currentWaveEnemy <= 0) _onSpawnNextWave.Raise();
    }
}
