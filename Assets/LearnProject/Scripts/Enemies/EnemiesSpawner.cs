using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    private float timer;

    private void FixedUpdate()
    {
        //if( !_isSpawned )
        //{
        //    _isSpawned = true;
        if (timer > 0)
            timer -= Time.fixedDeltaTime;
        else
        {
            timer = 3;
            var enemy = Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }
        //}
    }
}
