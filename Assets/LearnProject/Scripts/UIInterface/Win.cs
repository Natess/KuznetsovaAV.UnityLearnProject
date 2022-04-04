using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameplayInterface.ShowMessageInCentre("Вы прошли уровень", 2, () => { SceneManager.LoadScene(3); });

        }
    }
}
