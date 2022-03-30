using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{

    //private void CheckItCanBeOpened()
    //{
    //    if (_firstPresurePlate.Pressed && _secondPresurePlate.Pressed)
    //        Open();
    //}

    public void Open()
    {
        transform.rotation = new Quaternion(0, 170, 0, 0);
        Debug.Log("Ворота открыты!");
    }
}
