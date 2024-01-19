using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;

    public float Speed;

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3 (Horizontal, Vertical);

        transform.position += direction * Speed * Time.deltaTime;
    }
}
