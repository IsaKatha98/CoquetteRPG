using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesManager : MonoBehaviour
{

    [SerializeField] private Tilemap interactibleMap;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;

    void Start()
    {
        foreach(var position in interactibleMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactibleMap.GetTile(position);

            if(tile != null && tile.name.Equals("Interactable_Visible"))
            {
                interactibleMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactibleMap.GetTile(position);

        if (tile != null && tile.name.Equals("Interactable_Visible 1"))
        {
            return true;
      
        }

        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        interactibleMap.SetTile(position, interactedTile);
    }

}
