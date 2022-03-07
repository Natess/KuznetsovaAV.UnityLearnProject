using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _lifePoint;
    private Player _player;

    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    private float timer;

    [SerializeField]
    private float _speedRotate;

    void Start()
    {
        _player = FindObjectOfType<Player>();     
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 5)
        {
            var direction = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward,
                                                   direction,
                                                   _speedRotate * Time.fixedDeltaTime,
                                                   0f);
            transform.rotation = Quaternion.LookRotation(stepRotate);

            if (timer > 0)
                timer -= Time.fixedDeltaTime;
            else
            {
                timer = 3;
                Fire();
            }
        }
    }

    private void Fire()
    {
        var ability1Sphere = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        ability1Sphere.GetComponent<Bullet>().Init(_player.Target, 10, 0.2f);
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
