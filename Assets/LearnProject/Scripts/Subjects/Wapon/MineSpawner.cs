using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mine; 
    [SerializeField] private Transform _mineSpawnPoint;

    void Start()
    {
        print("Нажмите Е, чтобы использовать мину.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_mine, _mineSpawnPoint.position, _mineSpawnPoint.rotation);
        }
    }
}
