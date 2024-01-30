using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;
    private Vector3 direction;

    public float Speed;
    public Animator animator;

    private void FixedUpdate()
    {
        //get player input
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        //create normalized vector of the direction
        direction = new Vector3(Horizontal, Vertical, 0);

        //move the player
        transform.position += direction * Speed * Time.deltaTime;

        AnimateMovement(direction);
  
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if(direction.magnitude > 0)
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
