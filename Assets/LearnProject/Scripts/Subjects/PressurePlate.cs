using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]private GameObject _gate;
    public bool Pressed = false;
    public UnityEvent WasPressed;

    private void Start()
    {
        print("Чтобы открыть ворота передвиньте на ящик на нажимную плиту");
    }

    /// <summary>
    /// ### 5. * Реализовать толкаемый предмет как часть загадки (например, нужно подвинуть ящик на триггер).
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))//other.gameObject.CompareTag("Player") || 
        {
            Pressed = true;
            WasPressed.Invoke();
            //_gate.GetComponent<Gate>().CheckOpening.Invoke();
        }
    }
}
