using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _isOpen;
    private readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Awake()
    {
        _animator = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_isOpen)
            GameplayInterface.ShowMessageInRightUpCorner("Нажмите Q, чтобы ввести пароль", 2);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameplayInterface.ShowInputField("Чтобы открыть дверь нужно правильно ввести код в кодовый замок.", "4591", Open);
            }
        }
    }

    public void Open()
    {
        _isOpen = true;
        _animator.SetBool(IsOpen, true);
    }

}
