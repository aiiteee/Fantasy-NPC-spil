using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
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
            StartCoroutine(WaitToFollow());

            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }


    }

    IEnumerator WaitToFollow()
    {
        yield return new WaitForSeconds(timeWaited);
        FollowPlayer();
    }


    public void FollowPlayer()
    {

        animator.SetFloat("Horizontal", target.position.y - transform.position.y);
        animator.SetFloat("Vertical", target.position.x - transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }



    /*internal Transform thisTransform;
    public Animator animator;
    public bool move;

    // The movement speed of the object
    public float moveSpeed = 0.2f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero, Vector3.zero };
    internal int currentMoveDirection;

    // Use this for initialization
    void Start()
    {
        move=true;
        // Cache the transform for quicker access
        thisTransform = this.transform;
        // Set a random time delay for taking a decision ( changing direction,or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object in the chosen direction at the set speed
        Vector3 direction = moveDirections[currentMoveDirection];
        float xDir = direction.x;
        float yDir = direction.y;

        if (moveSpeed < 0.01)
        {
            move = false;
        }
        
        if (move)
        {
            animator.SetBool("Move", true);
        }

        thisTransform.position += direction * Time.deltaTime * moveSpeed;

        if (animator)
        {
            animator.SetFloat("Vertical", xDir);
            animator.SetFloat("Horizontal", yDir);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }

        if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
            // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

            // Choose a movement direction, or stay in place
            ChooseMoveDirection();
        }
    }

    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));


    }*/






















    /*[SerializeField] float speed;
    [SerializeField] float targetPosition;
    [SerializeField] Transform PlayerTransform;

    Rigidbody2D rb;

    Animator animator;

    Transform target;

    Vector2 movement;
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void TargetFollow()
    {
        if (Vector2.Distance(transform.position, target.position) > targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        


    }*/







}
