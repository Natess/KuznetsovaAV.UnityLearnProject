using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Если у вас есть ключ нажмите Q, чтобы открыть ворота.");
            if (Input.GetKeyDown(KeyCode.Q) 
                && collision.gameObject.GetComponent<Player>().Inventory.Exists("FirstKey"))
            {
                Open();
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Close(); 
        }
    }

    public void Open()
    { 
        _animator.SetBool(IsOpen, true);
        Debug.Log("Ворота открыты!");
    }


    public void Close()
    { 
        _animator.SetBool(IsOpen, false);
        Debug.Log("Ворота закрыты!");
    }
}
