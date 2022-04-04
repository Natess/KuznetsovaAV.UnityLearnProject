using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayInterface : MonoBehaviour
{
    [SerializeField] private GameObject _messageInCentreObject;
    [SerializeField] private GameObject _messageInRightUpCornerObject;
    [SerializeField] private GameObject _firstAbilityChargeIndicateObject;
    [SerializeField] private GameObject _noteObject;
    [SerializeField] private GameObject _inputTextObject;
    [SerializeField] private GameObject _pauseMenuObject;

    public static Fail Fail;
    private static MessageInCentre _messageInCentre;
    private static MessageInRightUpCorner _messageInRightUpCorner;
    private static FirstAbilityChargeIndicate _firstAbilityChargeIndicate;
    private static Note _note;
    private static InputText _inputText;
    private static Player _player;
    //private static PauseMenu _pauseMenu;

    private void Awake()
    {
        _messageInCentre = _messageInCentreObject.GetComponent<MessageInCentre>();
        _messageInRightUpCorner = _messageInRightUpCornerObject.GetComponent<MessageInRightUpCorner>();
        _firstAbilityChargeIndicate = _firstAbilityChargeIndicateObject.GetComponent<FirstAbilityChargeIndicate>();
        _note = _noteObject.GetComponent<Note>();
        _inputText = _inputTextObject.GetComponent<InputText>();
        _player = gameObject.GetComponent<Player>();
        //_pauseMenu = _pauseMenuObject.GetComponent<PauseMenu>();
        Fail = new Fail();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            _player.enabled = false;
            _pauseMenuObject.SetActive(true);
        }
    }

    public static void ShowMessageInCentre(string text, int time, Action action = null)
    {
        _messageInCentre.Show(text, time, action);
    }

    public static void ShowMessageInRightUpCorner(string text, int time)
    {
        _messageInRightUpCorner.Show(text, time);
    }

    internal static void Win()
    {
        _messageInCentre.Show("Поздравляем! Вы победили!", 3, () => SceneManager.LoadScene(0));
    }

    public static void ShowNote(string text)
    {
        _note.Open(text);
    }

    public static void ShowInputField(string text, string rightAnswer, Action action =  null)
    {
        _player.enabled = false;
        _inputText.Show(text, rightAnswer, action);
    }

    public static void PlayerDies()
    {
        Fail.PlayerDies();
    }

    #region FirstAbilityIndicate
    public static void FirstAbilityChargeIndicateOn()
    {
        _firstAbilityChargeIndicate.SetActive(true);
    }

    public static void FirstAbilityChargeIndicateSetChargeCount(int chargeCount)
    {
        _firstAbilityChargeIndicate.SetChargeCount(chargeCount);
    }

    public static void ActivePlayer()
    {
        _player.enabled = true;
    }

    #endregion
}