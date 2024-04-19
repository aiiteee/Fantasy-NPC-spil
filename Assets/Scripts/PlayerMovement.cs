using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /*[field: SerializeField] public float MoveForce { get; private set; } = 250f;

    [field: SerializeField] public AnimationClip Back { get; private set; }
    [field: SerializeField] public AnimationClip Front { get; private set; }
    [field: SerializeField] public AnimationClip Left { get; private set; }
    [field: SerializeField] public AnimationClip Right { get; private set; }
    [field: SerializeField] public AnimationClip Idle { get; private set; }

    private Vector2 axisInput = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AnimationClip = Idle;
    }

    private void FixedUpdate()
    {
        Vector2 moveForce = axisInput * MoveForce * Time.fixedDeltaTime;
        rb.AddForce(moveForce);
    }*/

    













    public float moveSpeed;
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
    }
}
