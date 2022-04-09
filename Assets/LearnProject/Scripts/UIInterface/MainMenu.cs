using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _exitGameButton;

    private void Awake()
    {
        _exitGameButton.onClick.AddListener(() => { Application.Quit(); });
        _startGameButton.onClick.AddListener(() => { SceneManager.LoadScene(2); });
    }
}
