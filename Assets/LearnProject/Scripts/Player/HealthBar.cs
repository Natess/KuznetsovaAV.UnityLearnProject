using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int _hitPoints;
    private Player _player;
    [SerializeField] private Slider _slider;

    public HealthBar(Player player, int hitPoints)
    {
        _hitPoints = hitPoints;
        _player = player;
        _slider.maxValue = hitPoints;
    }
    internal void Init(Player player, int hitPoints)
    {
        _hitPoints = hitPoints;
        _player = player;
        _slider.maxValue = hitPoints;
        _slider.value = hitPoints;
    }

    internal void TakeDamage(int damage)
    {
        _hitPoints -= damage;

        _slider.value = _hitPoints;

        if (_hitPoints <= 0)
            _player.PlayerDies();

    }

    public void AddHitpoint(int hitPoint)
    {
        _hitPoints += Math.Min(hitPoint, (int)Math.Floor(_slider.maxValue - _slider.value));
        _slider.value = _hitPoints;
    }

}
