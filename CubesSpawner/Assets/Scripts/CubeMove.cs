using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;

    private void Awake()
    {
        _speed = 2.5f;
    }

    private void Update()
    {
        _direction = new Vector3(_speed, 0, 0);
    }

    private void FixedUpdate()
    {
        transform.position += _direction * _speed * Time.fixedDeltaTime;
    }
}
