using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject playerPosition;

    private void Update()
    {
        transform.position = playerPosition.transform.position + offset;
    }
}
