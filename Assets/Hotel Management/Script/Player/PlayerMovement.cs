using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontal;
    private float vertical;

    [SerializeField] private float playerSpeed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");// *playerSpeed;
        vertical = Input.GetAxis("Vertical");// *playerSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {

        transform.Translate(new Vector3(horizontal * playerSpeed*Time.deltaTime, 0, vertical * playerSpeed * Time.deltaTime));

    }

}
