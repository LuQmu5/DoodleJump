using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _speed = 5;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
            {
                _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
                transform.eulerAngles = Vector3.zero;
            }
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }
    }
}

public class CharacterProgressHandler
{

}
