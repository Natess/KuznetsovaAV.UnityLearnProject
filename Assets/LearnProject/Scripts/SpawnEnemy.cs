using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
    }

    private void Move(float delta)
    {
        transform.position += _direction * _speed * delta;
    }
}
