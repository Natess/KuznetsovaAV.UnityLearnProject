using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour, ITakeDamage
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private bool _isFire = true;
    [SerializeField] private int _lifePoint;
    [SerializeField] private float _cooldown;
    [SerializeField]
    private float _speedRotate;

    void Awake()
    {
        _player = FindObjectOfType<Player>();
    }


    private void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, _player.transform.position) < 5)
        {
            var direction = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward,
                                                   direction,
                                                   _speedRotate * Time.fixedDeltaTime,
                                                   0f);
            transform.rotation = Quaternion.LookRotation(stepRotate);
        }


    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 6, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit, 6))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);
            Debug.DrawRay(hit.point, hit.normal, Color.magenta);

            if (hit.collider.CompareTag("Player"))
            {
                if (_isFire)
                    Fire();
            }
        }

    }

    private void Fire()
    {
        _isFire = false;
        var bulletPrefab = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        var bullet = bulletPrefab.GetComponent<Bullet>();
        bullet.Init(_player.transform, 10, 0.3f);
        Invoke(nameof(Reloading), _cooldown);
    }

    private void Reloading()
    {
        _isFire = true;
    }

    public void TakeDamage(int damage)
    {
        _lifePoint -= damage;
        if (_lifePoint < 0)
        {
            Destroy(gameObject);
            GameplayInterface.Win();
        }
    }

}
