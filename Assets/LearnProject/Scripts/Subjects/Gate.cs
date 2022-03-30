using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    private bool _isOpen = false;


    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("���� � ��� ���� ���� ������� Q, ����� ������� ������.");
            if (Input.GetKeyDown(KeyCode.Q) && collision.gameObject.GetComponent<Player>().Inventory.Exists(x => x.name == "FirstKey"))
            {
                if(_isOpen) Close();
                else Open();
            }
        }
    }

    public void Open()
    {
        transform.rotation = new Quaternion(0, 1, 0, 0);
        _isOpen = true;
        Debug.Log("������ �������!");
    }


    public void Close()
    {
        transform.rotation = new Quaternion(0.0f, 0.7f, 0.0f, 0.7f);
        _isOpen = false;
        Debug.Log("������ �������!");
    }
}
