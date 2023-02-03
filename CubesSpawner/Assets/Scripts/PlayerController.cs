using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    private float _horizontal;
    private float _vertical;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        Move();
    }

    private void Move()
    {
        _rb.AddForce(new Vector3(_horizontal, 0, _vertical));
    }
}
