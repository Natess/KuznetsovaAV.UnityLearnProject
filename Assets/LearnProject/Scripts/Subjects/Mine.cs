using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _radius = 1;
    [SerializeField] private float _lifeTime = 10f;
    [SerializeField] private float _force = 100;
    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0)
        {
            //Взрыв с ракидыванием
            var ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, _radius))
            {
                var coliders = Physics.OverlapSphere(this.transform.position, _radius);
                foreach (var colider in coliders)
                {
                    if (colider.GetComponent<Rigidbody>())
                        colider.GetComponent<Rigidbody>().AddForce((colider.transform.position - hit.point) * _force);
                    var enemy = colider.GetComponent<ITakeDamage>();
                    if (enemy != null)
                        enemy.TakeDamage(_damage);
                }
            }
            print("Бабах!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward);

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, _radius))
            {
                var coliders = Physics.OverlapSphere(this.transform.position, _radius);
                foreach (var colider in coliders)
                {
                    if (colider.GetComponent<Rigidbody>())
                        colider.GetComponent<Rigidbody>().AddForce((colider.transform.position - hit.point) * _force);
                    var enemy = colider.GetComponent<ITakeDamage>();
                    if (enemy != null)
                        enemy.TakeDamage(_damage);
                }
            }

            //var enemy = other.GetComponent<ITakeDamage>();
            //enemy.TakeDamage(_damage);
            print("Бабах!");
            Destroy(gameObject);
        }
    }
}

