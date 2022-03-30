using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    public void Init(Transform targer, float lifeTime, float speed)
    {
        _target = targer;
        _speed = speed;
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Àó÷!");
            Destroy(gameObject);
        }
    }
}
