using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MushiMovement : MonoBehaviour
{
    private float range;
    public Transform bunny;
    private float minDistance = 7.0f;
    private float attackDistance = 2.0f;
    private bool targetCollision = false;
    private float speed = 2.0f;
    public Animator animator;
    public int health = 1;
    public GameObject mushi;
   
    void Update()
    {
        //float h= Input.GetAxis("Horizontal")
        Vector3 direction = bunny.position - transform.position;
        range = Vector2.Distance(transform.position, bunny.position);//clacula la distancia entre Bunny y Mushi
        animator.SetBool("isRunning", false);
        //Si entre Bunny y Mushi hay una distancia menor que la establecida.
        if (range <= minDistance&&range>attackDistance)
        {
            Debug.Log("Mushi nos persigue");
            //Si no han colisionado todavía, la persigue.
            if (!targetCollision)
            {
                //cogemos la posición de Bunny.
                transform.LookAt(bunny.position);

                //Esto es para que mushi se gire en el sentido en el que está Bunny.
                if (direction.x >= 0.0f)
                {
                    transform.localScale = new Vector3(10.0f, 10.0f, 0.0f);

                    transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                    //Aquí debería empezar la animación.

                    Debug.Log("Va a la derecha.");

                }
                else
                {

                    transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

                    Debug.Log("Va a la izquierda.");

                }
                animator.SetBool("isRunning", true);

            }
   
        } else if (range<=attackDistance )
        {
            //Mushi ataque.
            Debug.Log("Mushi ataca");
            animator.SetTrigger("attack");
            
        }

        //Debug.Log("Mushi se ha parado");

    }   

    public void hit ()
    {
        health--;

        animator.SetTrigger("hit");

        if (health==0)
        {
            //Llamamos a la animación.
            Debug.Log("Mushi se muere");
            animator.SetTrigger("dead");

            Destroy(gameObject, 0.3f);
        }
    }
}
