using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerEnemy : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private bool _isFire = true;
    [SerializeField] private float _cooldown;
    private int _timeNotSeePlayer = 3;
    private bool _isStalkering = false;

    private MyWaypointPatrol _patrol;
    private NavMeshAgent _agent;

    void Awake()
    {
        _player = FindObjectOfType<Player>();
        _patrol = GetComponent<MyWaypointPatrol>();

        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStalkering)
        {
            ++_timeNotSeePlayer;
            _agent.SetDestination(_player.transform.position);
            _patrol.OnPatrol = false;
        }


        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 6, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit, 6))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);
            Debug.DrawRay(hit.point, hit.normal, Color.magenta);

            if (hit.collider.CompareTag("Player"))
            {
                _isStalkering = true;
                _timeNotSeePlayer = 0;
                //_agent.SetDestination(_player.transform.position);
                if (_isFire)
                    Fire();
            }
        }

        if (_isStalkering)
        {
            if (_timeNotSeePlayer > 400)
                _agent.SetDestination(transform.position);
            if (_timeNotSeePlayer > 750)
            {
                _isStalkering = false;
                _patrol.ContinuePatrol();
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
}
