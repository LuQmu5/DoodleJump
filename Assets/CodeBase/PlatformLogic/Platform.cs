using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [field: SerializeField] public PlatformType Type { get; private set; }
    [field: SerializeField] public float PushPower { get; private set; }

    private float _extraPushForce = 1;
    private int _extraPushCounter = 0;
    private int _extraPushCountLimit = 4;

    public void Init(PlatformType type, float pushPower)
    {
        Type = type;
        PushPower = pushPower;
        _extraPushCounter = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigidbody) && rigidbody.velocity.y < 0)
        {
            if (_extraPushCounter < _extraPushCountLimit)
                _extraPushCounter++;
            else
                _extraPushCounter = 0;

            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * (PushPower + (_extraPushForce * _extraPushCounter)), ForceMode2D.Impulse);
        }
    }

    private void OnBecameInvisible() => gameObject.SetActive(false);
}
