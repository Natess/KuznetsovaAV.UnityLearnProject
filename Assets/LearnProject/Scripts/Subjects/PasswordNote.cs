using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordNote : MonoBehaviour
{
    [SerializeField] private string _password; 

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
            GameplayInterface.ShowNote(_password);
            //enabled = false;
            gameObject.SetActive(false);
        }
    }
}
