using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]private Gate _gate;

    private void Start()
    {
        print("Чтобы открыть ворота передвиньте на ящик на нажимную плиту");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Player")) 
        {
            _gate?.Open(); 
        }
    }
}
