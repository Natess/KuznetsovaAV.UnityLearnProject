using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed = 5f;
    private bool inJump;

    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction.z = -Input.GetAxis("Horizontal");
        _direction.x = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && !inJump)
        {
            inJump = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
        }
    }

    private void Move(float delta)
    {
        transform.position += _direction * _speed * delta;
    }

    private void OnCollisionEnter(Collision collision)
    {
        inJump = false;
    }
}
