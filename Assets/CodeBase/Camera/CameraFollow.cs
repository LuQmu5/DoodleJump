using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float _maxOffsetY;
    public float _speed;
    public Character _character;

    private void Update()
    {
        if (_character.transform.position.y - transform.position.y > _maxOffsetY)
        {
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
        }
    }
}
