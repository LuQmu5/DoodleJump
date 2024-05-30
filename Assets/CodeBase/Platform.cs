using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rb) && rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        }
    }

    private void OnBecameInvisible()
    {
        
    }
}
