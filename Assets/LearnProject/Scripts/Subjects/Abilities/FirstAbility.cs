using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FirstAbility : TakeMagicItem
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private FirstAbilitySphere _prefab;
    [SerializeField] private int _charges;

    public void Use()
    {
        if (_charges > 0)
        {
            var ability1Sphere = Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
            ability1Sphere.GetComponent<FirstAbilitySphere>().Init(4, 2f, 5);
            --_charges;
        }
        else
        {
            print("Нет зарядов!");
        }
    }

    internal void AddCharges(FirstAbilityCharge ability1Charge)
    {
        _charges += ability1Charge.Count;
        print($"У вас {_charges} заряда(ов)!");
    }
}
