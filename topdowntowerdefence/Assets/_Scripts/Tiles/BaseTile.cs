using System;
using System.Collections;
using UnityEngine;

public class BaseTile : MonoBehaviour
{
    public enum TileType { Land, Path, Obstacle };
    public TileType Type;

    public delegate void TileDelegate(BaseTile self);
    public static event TileDelegate OnTileSelect;

    

    private void OnMouseDown()
    {
        if (OnTileSelect != null) OnTileSelect(this);
    }
}

