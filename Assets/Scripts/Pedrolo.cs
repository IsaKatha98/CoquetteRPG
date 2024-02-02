using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Es la misma lógica que el Hacha, pero va a ser el "arma" del enemiga.
public class Pedrolo : MonoBehaviour
{
    private float weaponY;
    private float weaponX = 1f;
    Vector3 pos;//indica la posición.
    public GameObject isHolding;


    // Update is called once per frame
    void Update()
    {
        if (isHolding != null)
        {
            //Para que el hacha no se vea en el juego.
            GameObject.Find("Pedrolo").transform.localScale = new Vector3(0, 0, 0);

            pos = isHolding.transform.position;

            //indicamos la posición del hacha con respecto a Bunny.
            pos.x += weaponX;
            pos.y += weaponY;
            transform.position = pos;

            //En el caso de que el enemigo se encuentre a nuestr izquierda, cambiamos el hacha de posición.
            //esto es más visual que otra cosa, se podría hasta quitar.
            if (weaponX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;

            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }


        }


    }

    //Cuando el collider haga contacto, comprobamos que es bunny y hacemos el daño correspondiente.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //llamamos al script de bunny
        BunnyScript bunny = collision.GetComponent<BunnyScript>();

        if (bunny != null)
        {
            Debug.Log("Le hemos dado a Bunny");
            bunny.hit();
        }

    }
}
