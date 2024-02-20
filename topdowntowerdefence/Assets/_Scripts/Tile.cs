using System;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType { Land, Path, Obstacle };
    public TileType Type;

    public bool Interactable = true;

    public GameObject SpawnedObject;

    public delegate void TileDelegate(Tile self);
    public static event TileDelegate OnTileSelect;

    public void OnMouseDown()
    {
        if (OnTileSelect != null)
        {
            OnTileSelect(this);
        }
    }

    public void SpawnObject(GameObject targetObject)
    {
        if (SpawnedObject == null)
        {
            GameObject obj = Instantiate(targetObject, transform.position, Quaternion.identity);
            obj.transform.parent = targetObject.transform;
            Interactable = false;
        }
    }

    public void DeleteSpawnedObject()
    {
        if (SpawnedObject != null)
        {
            Destroy(SpawnedObject);
            Interactable = true;
        }
    }
}

