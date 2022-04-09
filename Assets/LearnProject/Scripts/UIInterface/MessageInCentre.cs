using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class MessageInCentre : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    [SerializeField] private float _lifeTime = 2f;

    private void Awake()
    {
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Show(string text, int timeInSeconds, Action action = null)
    {
        textMeshPro.text = text;
        _lifeTime = timeInSeconds;
        StartCoroutine(ShowText(action));
    }

    IEnumerator ShowText(Action action)
    {
        textMeshPro.enabled = true;
        yield return new WaitForSecondsRealtime(_lifeTime);
        textMeshPro.enabled = false;
        action?.Invoke();
    }

}
