using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IsometricPlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    private Rigidbody2D rbody;
    private bool isGrounded;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0f; // Pas de gravité dans un jeu isométrique
        rbody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Vérifie si le joueur touche le sol (utile si tu veux des actions au sol)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Récupère les inputs
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(inputX, inputY).normalized;

        // Applique directement la vélocité dans les deux axes (X et Y)
        Vector2 velocity = input * movementSpeed;
        rbody.velocity = velocity;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
