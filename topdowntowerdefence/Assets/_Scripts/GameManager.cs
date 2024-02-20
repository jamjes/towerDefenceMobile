using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject PortalPrefab;
    public GameObject BombPrefab;

    public Tile TargetTile;

    public delegate void TileDelegate(Tile self);
    public static event TileDelegate OnTileSelect;
    public static event TileDelegate OnTileDeselect;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SelectTile(Tile target)
    {
        TargetTile = target;

        if (OnTileSelect != null)
        {
            OnTileSelect(TargetTile);
        }
    }

    public void DeselectTile(Tile target)
    {
        TargetTile = null;

        if (OnTileDeselect != null)
        {
            OnTileDeselect(TargetTile);
        }
    }

    public void SpawnBomb()
    {
        Instantiate(BombPrefab, TargetTile.transform.position, Quaternion.identity);
        DeselectTile(TargetTile);
    }

    public void SpawPortal()
    {
        Instantiate(PortalPrefab, TargetTile.transform.position, Quaternion.identity);
        DeselectTile(TargetTile);
    }
}
