using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;
    [SerializeField] private float _speed = 5f;
    private bool _inJump;
    [SerializeField] private float _speedRotate = 200f;
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody _rb;

    public Transform Target;

    #region Abilities

    public bool HaveAbility1 { get => _ability1 != null; }
    private Ability1 _ability1;

    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
        //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * _speedRotate * Time.fixedDeltaTime, 0));
    }

    void Update()
    {
        if (_ability1!=null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ability1.Use();
        }
        Jump();
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

    /// <summary>
    /// Прыжок
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_inJump)
        {
            _inJump = true;
           _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void Move(float delta)
    {
        // Переделено на движение по физике
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _direction = transform.TransformDirection(_direction);
        _rb.MovePosition(transform.position + _direction.normalized * _speed * delta);

        var rotate = new Vector3(0f, Input.GetAxis("Mouse X") * _speedRotate * delta, 0f);
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotate));

        //var fixedDirection = transform.TransformDirection(_direction.normalized);
        //transform.position += fixedDirection * _speed * delta;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
         _inJump = false;
    }
}
