using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] private string _rightAnswer;
    [SerializeField] private Text _text;
    [SerializeField] private InputField _inputField;
    Action _action;

    private void Awake()
    {
        gameObject.SetActive(false);
        ////_inputField.Select();
        ////_inputField.ActivateInputField(); 
        //EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);
        //_inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    public void Show(string text, string rightAnswer, Action action)
    {
        Time.timeScale = 0f;
        _text.text = text;
        _action = action;
        _rightAnswer = rightAnswer;
        GameplayInterface.ShowMessageInRightUpCorner("Чтобы закрыть нажмите R, чтобы проверить пароль нажмите E", 50);
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inputField.text = _inputField.text.Trim('e');
            if (_inputField.text == _rightAnswer)
            {
                gameObject.SetActive(false);
                Time.timeScale = 1f;
                GameplayInterface.ActivePlayer();
                _action?.Invoke();
            }
            else
            {
                GameplayInterface.ShowMessageInRightUpCorner("Пароль неверный", 50);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _inputField.text = _inputField.text.Trim('r');
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

    }
}
