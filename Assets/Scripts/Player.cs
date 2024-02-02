using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(9);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x,
                (int)transform.position.y, 0);

            if(GameManager.Instance.tilesManager.IsInteractable(position))
            {
                Debug.Log("Tile is interactable");
                GameManager.Instance.tilesManager.SetInteracted(position);
            }
        }
    }
}
