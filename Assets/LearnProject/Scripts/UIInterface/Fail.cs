using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    private static bool _isDead;

    private void Awake()
    {
        _isDead = false;
    }

    internal void PlayerDies()
    {
        if (!_isDead)
        {
            _isDead = true;
            GameplayInterface.ShowMessageInCentre("Вы погибли", 2, () => { SceneManager.LoadScene(0); });
        }
    }
}
