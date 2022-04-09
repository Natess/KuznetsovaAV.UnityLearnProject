using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mine; 
    [SerializeField] private Transform _mineSpawnPoint;

    void Start()
    {
        //print("������� �, ����� ������������ ����.");
        GameplayInterface.ShowMessageInRightUpCorner("������� �, ����� ������������ ����.", 2);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale > 0f)
        {
            Instantiate(_mine, _mineSpawnPoint.position, _mineSpawnPoint.rotation);
        }
    }
}
