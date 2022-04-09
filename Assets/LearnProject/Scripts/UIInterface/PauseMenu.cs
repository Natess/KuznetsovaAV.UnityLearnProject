using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _continueGameButton;
    [SerializeField] private Button _exitGameButton;

    private void Awake()
    {
        gameObject.SetActive(false);


        _exitGameButton.onClick.AddListener(() => { Application.Quit(); });

        _continueGameButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            GameplayInterface.ActivePlayer();
            gameObject.SetActive(false);
        });
    }
}
