using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private int _lifePoint;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
    }

    private void Move(float delta)
    {
        transform.position += _direction * _speed * delta;
    }

    public void TakeDamage(int damage)
    {
        _lifePoint -= damage;
        if (_lifePoint < 0)
        {
            print("Враг убит!");
            Destroy(gameObject);
        }
    }
}
