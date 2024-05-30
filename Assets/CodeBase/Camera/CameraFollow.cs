using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _maxOffsetY;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _followTarget;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        float distanceDelta = _followTarget.transform.position.y - transform.position.y;

        if (distanceDelta > _maxOffsetY)
            transform.Translate(Vector2.up * Time.deltaTime * _speed * distanceDelta);
    }
}
