using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public float MoveForce { get; private set; } = 250f;

    private Vector2 axisInput = Vector2.zero;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveForce = axisInput * MoveForce * Time.fixedDeltaTime;
    }

    public float work = 4f;













    /*public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }*/
}
