using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(_cube);
        }
    }
}
