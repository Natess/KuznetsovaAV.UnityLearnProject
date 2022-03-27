using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (enabled && other.gameObject.CompareTag("Player"))
        {
            print("Чтобы подобрать предмет нажмите Q!");
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (enabled && other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            other.GetComponent<Player>().AddItem(gameObject);
            enabled = false;
            //Destroy(gameObject);
            gameObject.SetActive(false);

        }
    }
}
