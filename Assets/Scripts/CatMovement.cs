using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] float speed;
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
    }

    public void TargetFollow()
    {
        if (Vector2.Distance(transform.position, target.position) > targetPosition)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        


    }

    

    
}
