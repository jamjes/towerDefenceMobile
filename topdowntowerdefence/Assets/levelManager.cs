using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public Transform[] path;

    public static levelManager Instance;

    public GroundTile[] tiles;
    public GroundTile activeTile;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetActiveTile(GroundTile tile)
    {
        if (activeTile != null)
        {
            //activeTile.Deselect();

            if (activeTile == tile)
            {
                activeTile = null;
                return;
            }
        }

        activeTile = tile;
        //activeTile.Select();
        DisableAllOtherTiles();
    }

    void DisableAllOtherTiles()
    {
        foreach(GroundTile t in tiles)
        {
            Debug.Log($"t: {t.name}, target: {activeTile.name}");
        }
    }
}
