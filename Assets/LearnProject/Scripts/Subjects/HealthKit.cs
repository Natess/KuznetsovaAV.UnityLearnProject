using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : TakeItem
{
    [SerializeField] private int _hitPoint;

    private void Awake()
    {
        _hitPoint = Random.Range(1, 15);
    }

    public override void OnTriggerStay(Collider other)
    {
        if (enabled && other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            GameplayInterface.ShowMessageInRightUpCorner("Вы подобрали предмет", 2);
            other.GetComponent<Player>().HealthBar.AddHitpoint(_hitPoint);
            enabled = false;
            gameObject.SetActive(false);
        }
    }
}
