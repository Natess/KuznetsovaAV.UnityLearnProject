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

    [SerializeField] private float _cooldown = 2f;
    [SerializeField]
    private float _speedRotate;

    [SerializeField] private bool _isFire;

    void Start()
    {
        _player = FindObjectOfType<Player>();     
    }


    /// <summary>
    /// ### 4. Сделайте простой ИИ, способный регистрировать в своем поле зрения игрока и атаковать его
    /// a.Сделайте так чтобы противник мог терять из виду игрока.
    /// </summary>
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
        }

        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 6, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit, 6))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (_isFire)
                    Fire();
            }
        }


        //    if (timer > 0)
        //        timer -= Time.fixedDeltaTime;
        //    else
        //    {
        //        timer = 2;
        //        Fire();
        //    }
        //}
    }

    private void Fire()
    {
        _isFire = false;
        var ability1Sphere = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        ability1Sphere.GetComponent<Bullet>().Init(_player.Target, 10, 0.2f);
        Invoke(nameof(Reloading), _cooldown);
    }

    private void Reloading()
    {
        _isFire = true;
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
