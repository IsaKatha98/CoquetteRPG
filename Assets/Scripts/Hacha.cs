using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacha : MonoBehaviour
{
   
    private float weaponY;
    private float weaponX = 1f;
    public Animator animator;

    Vector3 pos;//indica la posici�n.
    public GameObject isHolding;

    //Aqu�, vamos a tener un hacha figurada que es la que hace contacto con Mushi 
    //y le da�a. En el juego no se va a ver porque tenemos la animaci�n integrada con Bunny.

    // Update is called once per frame
    void Update()
    {
        //Para que el hacha no se vea en el juego.
        GameObject.Find("Hacha").transform.localScale = new Vector3(0, 0, 0);
       
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            Attack();
        }
    }

    void Attack()
    {
        //Llamamos a las animaciones de Bunny.
        animator.SetTrigger("attack");
        Debug.Log("Bunny ataque");

        //para que siempre lleve el hacha encima.
        pos = isHolding.transform.position; //guarda la posici�n de Bunny.

        //indicamos la posici�n del hacha con respecto a Bunny.
        pos.x += weaponX;
        pos.y += weaponY;
        transform.position = pos;

        //En el caso de que el enemigo se encuentre a nuestr izquierda, cambiamos el hacha de posici�n.
        //esto es m�s visual que otra cosa, se podr�a hasta quitar.
        if (weaponX<0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //llamamos al script de mushi
        MushiMovement mushi = collision.GetComponent<MushiMovement>();

        if (mushi != null)
        {
            Debug.Log("Le hemos dado a Mushi");
            mushi.hit();
        }

    }
}
