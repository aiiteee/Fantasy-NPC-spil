using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hexTime = 3;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            moveSpeed = 0;
            animator.SetFloat("Hexed", 1);
            Invoke("deHex", hexTime);
        }
    }
    void deHex()
    {
        animator.SetFloat("Hexed", 0);
        Invoke("deFrog", 1);
    }
    void deFrog()
    {
        moveSpeed = 5;
    }
}
