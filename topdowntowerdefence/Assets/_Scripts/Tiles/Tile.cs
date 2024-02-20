using System;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType { Land, Path, Obstacle };
    public TileType Type;

    public delegate void TileDelegate(Tile self);
    public static event TileDelegate OnTileClick;

    

    private void OnMouseDown()
    {
        if (OnTileClick != null) OnTileClick(this);
    }
}

