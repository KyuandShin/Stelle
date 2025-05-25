using UnityEngine;

public class StelleController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Apply movement
        transform.position += (Vector3)movement.normalized * moveSpeed * Time.deltaTime;

        // Update animation
        bool isWalking = movement != Vector2.zero;
        animator.SetBool("isWalking", isWalking);
    }
}