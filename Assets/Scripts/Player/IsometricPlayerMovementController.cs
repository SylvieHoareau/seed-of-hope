using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IsometricPlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0f; // Pas de gravité
        rbody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(inputX, inputY).normalized;
        Vector2 velocity = input * movementSpeed;

        rbody.velocity = velocity;
        rbody.linearVelocity = velocity;
    }
}
