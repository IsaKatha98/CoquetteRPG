using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject bunny; //referencia a bunny
    public Animator animator;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //llamamos al collider de bunny.
        BunnyScript bunny = collision.GetComponent<BunnyScript>();

        if (bunny != null)
        {
            animator.SetTrigger("isOpen");
            Debug.Log("Abrimos la puerta.");

        }
    }

    /// <summary>
    /// Método que hace cargar el mismo nivel en el que estamos.
    /// </summary>
    private void restartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetSceneByName(Dungeon));

    }
}
