using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _powerUpPrefabs;
    [SerializeField] private float _powerUpSpawnInterval = 15f;

    private float _powerUpSpawnTimer = 0f;
    private int _randomizedPowerUpIndex;
    private float _addtionalRandomizedY;

    private void Update()
    {
        _powerUpSpawnTimer += Time.deltaTime;

        if (_powerUpSpawnTimer >= _powerUpSpawnInterval)
        { 
            SpawnPowerUp();
            _powerUpSpawnTimer = 0f;
        }
    }
    
    private void SpawnPowerUp()
    {
        _randomizedPowerUpIndex = Random.Range(0, _powerUpPrefabs.Length);
        _addtionalRandomizedY = Random.Range(-3.0f, 3.0f);
        GameObject powerUp = ObjectPool.Instance.GetObjectFromPool(_powerUpPrefabs[_randomizedPowerUpIndex]);
        powerUp.transform.position = new Vector3(transform.position.x,transform.position.y + _addtionalRandomizedY,transform.position.z);
        powerUp.transform.rotation = transform.rotation;
        if (!powerUp.TryGetComponent<PowerUp>(out PowerUp powerUpComp)) return;
        powerUpComp.LaunchPowerUp();
    }

}
