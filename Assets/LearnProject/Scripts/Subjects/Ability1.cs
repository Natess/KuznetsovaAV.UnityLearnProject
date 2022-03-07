using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Ability1 : TakeItem
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Ability1Sphere _prefab;


    public void Use()
    {
        var ability1Sphere = Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
        ability1Sphere.GetComponent<Ability1Sphere>().Init(4, 2f, 5);
    }

}
