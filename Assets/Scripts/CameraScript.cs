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
            //Posición actual de la cámara
            Vector3 posicion = transform.position;

            //Posición de Bunny
            posicion.x = Bunny.transform.position.x;
            posicion.y = Bunny.transform.position.y;

            //La posición actual de la camera toma la posición de Bunny
            transform.position = posicion;
        }

    }
}
