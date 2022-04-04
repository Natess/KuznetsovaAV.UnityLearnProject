using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Open (string text)
    {
        Time.timeScale = 0f;
        _text.text = text;
        GameplayInterface.ShowMessageInRightUpCorner("Чтобы закрыть нажмите E", 50);
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
