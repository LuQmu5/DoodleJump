using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _speed = 5;
    private CharacterProgressHandler _progressHandler;

    [Inject]
    public void Construct(CharacterProgressHandler progressHandler)
    {
        _progressHandler = progressHandler;
    }

    private void Update()
    {
        Move();

        if (transform.position.y > _progressHandler.MaxHeight)
            _progressHandler.SetMaxHeight(transform.position.y);
    }

    private void Move()
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
