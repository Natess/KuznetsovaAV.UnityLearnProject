using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed = 5f;
    private bool _inJump;
    private float _speedRotate = 200f;
    
    public Transform Target;

    #region Abilities

    public bool HaveAbility1 { get => _ability1 != null; }
    private Ability1 _ability1;

    #endregion

    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * _speedRotate * Time.fixedDeltaTime, 0));
    }

    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && !_inJump)
        {
            _inJump = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
        }

        if (_ability1!=null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ability1.Use();
        }
    }

    internal void AddItem(GameObject gameObject)
    {
        if (gameObject.name == "Ability1")
        {
            _ability1 = gameObject.GetComponent<Ability1>();
            print("Теперь вы можете стрелять по левой кнопке мыши.");
        }
        if (gameObject.CompareTag("Charge1"))
        {
            _ability1.AddCharges(gameObject.GetComponent<Ability1Charge>());
        }
    }

    private void Move(float delta)
    {
        var fixedDirection = transform.TransformDirection(_direction.normalized);
        transform.position += fixedDirection * _speed * delta;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _inJump = false;
    }
}
