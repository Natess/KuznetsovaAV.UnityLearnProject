using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    private float _speed = 1f;
    private Vector3 _direction = new Vector3(1, 0, 0);
    private int _stepsLimit = 5;
    private Vector3 _startPosition;
    [SerializeField] private int _lifePoint;


    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Math.Abs((transform.position - _startPosition).magnitude) >= _stepsLimit)
            _direction = -_direction;
        Step(Time.fixedDeltaTime);
    }

    private void Step(float delta)
    {
        transform.position += _direction * _speed * delta;

    }

    public void TakeDamage(int damage)
    {
        _lifePoint -= damage;
        if (_lifePoint <= 0)
        {
            Destroy(gameObject);
            print("Враг убит!");
        }
    }
}
