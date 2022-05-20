using Assets.LearnProject.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    private Vector3 _direction;
    private bool _inJump;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedRotate = 200f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Animator _animator;


    private readonly int IsWalking = Animator.StringToHash("IsWalking");
    private readonly int InJump = Animator.StringToHash("InJump");

    public HealthBar HealthBar;
    private Rigidbody _rb;
    public Transform Target;

    #region Properties
    public MagicBook MagicBook { get; private set; }
    public Inventory Inventory { get; private set; }
    
    #endregion

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        HealthBar = GetComponent<HealthBar>();// (this, 20);
        HealthBar.Init(this, 30);
        Inventory = new Inventory();
        MagicBook = new MagicBook();
    }

    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
    }

    void Update()
    {
        if (MagicBook.HaveFirstAbility && Input.GetKeyDown(KeyCode.Mouse0))
        {
            MagicBook.FirstAbility.Use();
        }
        Jump();
    }

    internal void AddMagicItem(GameObject gameObject)
    {
        MagicBook.AddAbility(gameObject);
    }

    internal void AddItem(GameObject gameObject)
    {
        Inventory.AddItem(gameObject);
    }

    #region Движение

    /// <summary>
    /// Прыжок
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_inJump)
        {
            _inJump = true;
           _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.SetBool(InJump, true);
        }
    }

    private void Move(float delta)
    {
        // Переделено на движение по физике
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _direction = transform.TransformDirection(_direction);
        _rb.MovePosition(transform.position + _direction.normalized * _speed * delta);

        _animator.SetBool(IsWalking, _direction != Vector3.zero);

        var rotate = new Vector3(0f, Input.GetAxis("Mouse X") * _speedRotate * delta, 0f);
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotate));

    }
    
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _animator.SetBool(InJump, false);
            _inJump = false;
        }
    }

    public void TakeDamage(int damage)
    {
        HealthBar.TakeDamage(damage);
    }

    internal void PlayerDies()
    {
        GameplayInterface.PlayerDies();
    }
}
