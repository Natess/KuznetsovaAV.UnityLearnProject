using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Ability1Sphere : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _force = 3;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(float lifeTime, float speed, int damage)
    {
        _speed = speed;
        _damage = damage;
        Destroy(gameObject, lifeTime);

        //_rigidbody.AddForce(transform.forward * _force);
    }

    void FixedUpdate()
    {
        // Сделан снаряд основанный на физике
        _rigidbody.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }

    //private void FixedUpdate()
    //{
    //    transform.position += transform.forward * _speed * Time.fixedDeltaTime;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<ITakeDamage>();
            enemy.TakeDamage(_damage);
            print("Пиу!");
            Destroy(gameObject);
        }
    }
}
