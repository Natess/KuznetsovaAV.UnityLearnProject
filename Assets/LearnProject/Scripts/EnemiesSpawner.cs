using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    private float timer;

    //private bool _isSpawned;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if( !_isSpawned )
        //{
        //    _isSpawned = true;
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = 3;
            var enemy = Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }
        //}
    }
}
