using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 2.0f;
    private Vector3 direction;
    Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get player input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //create normalized vector of the direction
        direction = new Vector3(horizontal, vertical, 0);

        //move the player
        transform.position += direction * speed * Time.deltaTime;

        AnimateMovement(direction);
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
