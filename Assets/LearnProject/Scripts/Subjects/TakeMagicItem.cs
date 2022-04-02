﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TakeMagicItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (enabled && other.gameObject.CompareTag("Player"))
        {
            print("Чтобы подобрать предмет нажмите Q!");
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (enabled && other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            other.GetComponent<Player>().AddMagicItem(gameObject);
            enabled = false;
            gameObject.SetActive(false);
        }
    }
}
