using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] List<Tile> tiles;

    private void OnEnable()
    {
        Tile.TileEffector += DeselectAll;
    }

    private void OnDisable()
    {
        Tile.TileEffector -= DeselectAll;
    }

    void DeselectAll()
    {
        foreach(Tile t in tiles)
        {
            t.Deselect();
        }
    }
}
