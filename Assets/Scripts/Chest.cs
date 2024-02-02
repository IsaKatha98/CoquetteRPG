using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{

    public GameObject bunny; //referencia a bunny
    public Animator animator;
    public GameObject semilla;
    public Vector3 positionSemilla = Vector3.zero;
    public GameObject door;
  
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //llamamos al collider de bunny.
        BunnyScript bunny = collision.GetComponent<BunnyScript>();

        //Semilla será invisible hasta que Bunny abra el cofre.
        GameObject.Find("StrawberryCollectable").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Door").transform.localScale = new Vector3(0, 0, 0);

        if (bunny!= null)
        {
           animator.SetTrigger("isOpen");
           Debug.Log("Abrimos el cofre.");

            //ponemos la semilla visible.
            Invoke("semillaVisible", 1f);

           
            
        }
    }

    private void semillaVisible()
    {
        GameObject.Find("StrawberryCollectable").transform.localScale = new Vector3(1.5f, 1.5f, 0);
        GameObject.Find("Door").transform.localScale = new Vector3(10, 10, 0);


    }

}
