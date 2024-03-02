using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameEventNoParam _onShoot;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] protected Transform _spawnPoint;
    [SerializeField] private float _bulletSpawnInterval = 0.5f;

    private float _bulletSpawnTimer = 0f;

    //Function yang di panggil setiap waktu berlangsungnya game
    private void Update()
    {
        _bulletSpawnTimer += Time.deltaTime;

        //if statement untuk menghitung timer kapan bullet dimunculkan dari pesawat, bila _bulletspawntimer sudah melebihi _bulletSpawnInterval (jumlah _bulletSpawnInterval disesuaikan dengan variable diatas) maka method SpawnBullet() akan terpanggil
        if (_bulletSpawnTimer >= _bulletSpawnInterval)
        {
            SpawnBullet();
            _bulletSpawnTimer = 0f;
        }
    }

    //Function untuk memunculkan game object bullet dengan posisi yang sesuai dengan spawn point gameobject
    public void SpawnBullet()
    {
        GameObject bullet = ObjectPool.Instance.GetObjectFromPool(_bulletPrefab);
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;
        if (!bullet.TryGetComponent<Bullet>(out Bullet bulletComp)) return;
        bulletComp.LaunchBullet();
        if (_onShoot != null) _onShoot.Raise();
    }
}
