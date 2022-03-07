using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]private GameObject _gate;

    private void Start()
    {
        print("����� ������� ������ �������� �� �������� �����");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gate.GetComponent<Gate>().Open();
        }
    }
}
