using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = _camera.position - _player.position;
    }

    public void Update()
    {
        _camera.position = _player.position + _offset;
    }
}
