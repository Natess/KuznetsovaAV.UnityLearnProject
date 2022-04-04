using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAbilityChargeIndicate : MonoBehaviour
{
    [SerializeField] private Text _chargeCount;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    internal void SetChargeCount(int chargeCount)
    {
        _chargeCount.text = chargeCount.ToString();
    }
}
