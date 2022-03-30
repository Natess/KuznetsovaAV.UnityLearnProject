using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _lifePoint;

    public void TakeDamage(int damage)
    {
        _lifePoint -= damage;
        if (_lifePoint <= 0)
        {
            Destroy(gameObject);
            print("Коробка сломана!");
        }
    }

}
