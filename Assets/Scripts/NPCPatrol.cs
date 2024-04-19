using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public float moveSpeed=2f;
    public Transform target;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    [SerializeField] private float timeWaited;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 moveDirection;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();

        }
        

    }


    public void FollowPlayer()
    {
        animator.SetBool("Move", true);
        animator.SetFloat("Horizontal", target.position.y - transform.position.y);
        animator.SetFloat("Vertical", target.position.x - transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    /*private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }*/

    /*public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public bool isMoving;
    public GameObject player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
            //animator.SetBool("Move", false);
        }

        Vector2 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        if (speed>0.01)
        {
            animator.SetBool("Move", true);
        }
        

        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);

        
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }*/
}
