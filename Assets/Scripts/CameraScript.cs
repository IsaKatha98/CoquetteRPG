using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Bunny;

    void Update()
    {
        if (Bunny != null)
        {
            //Posici�n actual de la c�mara
            Vector3 posicion = transform.position;

            //Posici�n de Bunny
            posicion.x = Bunny.transform.position.x;
            posicion.y = Bunny.transform.position.y;

            //La posici�n actual de la camera toma la posici�n de Bunny
            transform.position = posicion;
        }

    }
}
