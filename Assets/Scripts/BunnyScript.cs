using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class BunnyScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 5.0f;
    private Vector3 direction;
    Rigidbody2D rb;
    public Animator animator;
    public int health = 1;
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

    public void hit()
    {
        health--;

        if (health == 0)
        {
            //Llamamos a la animación.
            Debug.Log("Mushi se muere");
            animator.SetTrigger("dead");

            Destroy(gameObject, 0.3f);

            restartLevel();
        }

    }

    /// <summary>
    /// Método que hace cargar el mismo nivel en el que estamos.
    /// </summary>
    private void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
