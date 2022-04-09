using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (enabled && other.gameObject.CompareTag("Player"))
        {
            GameplayInterface.ShowMessageInRightUpCorner("Чтобы подобрать предмет нажмите Q!", 1);
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (enabled && other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            GameplayInterface.ShowMessageInRightUpCorner("Вы подобрали предмет", 2);
            other.GetComponent<Player>().AddItem(gameObject);
            enabled = false; 
            gameObject.SetActive(false);

        }
    }
}
