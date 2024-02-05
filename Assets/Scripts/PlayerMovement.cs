using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput, forwardInput;
    private float speed = 8f;
    private float rotationSpeed = 100f;

    private bool canMove;
    private float playerRadius = 1f;
    private float playerHeight = 1.5f;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput);

        float moveDistance = speed * Time.deltaTime * forwardInput;
        canMove = !Physics.CapsuleCast(transform.position, 
                                       transform.position + Vector3.up * playerHeight,
                                       playerRadius, transform.forward, moveDistance);
        
        if (canMove) { transform.Translate(Vector3.forward * moveDistance); }
    }
}
