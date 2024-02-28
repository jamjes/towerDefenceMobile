using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundTile : MonoBehaviour
{
    public enum TileType { Grass, Path };
    public TileType Type; //{ get; private set; }
    public GameObject SpawnedObject { private set; get; }

    SpriteRenderer spriteRenderer;

    [SerializeField] Color baseColor, highlightColor;


    //bool selected;

    public delegate void GroundTileDelegate(GroundTile tile);
    //public static event GroundTileDelegate OnTileHoverEnter;
    public static event GroundTileDelegate OnTileSelect;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnEnable()
    {
        UIButton.OnTurretSpawn += Deselect;
        UIButton.OnTurretDismantle += Deselect;
    }

    private void OnDisable()
    {
        UIButton.OnTurretSpawn -= Deselect;
        UIButton.OnTurretDismantle -= Deselect;
    }

    void OnMouseEnter() => Highlight();

    private void OnMouseExit() => Deselect();

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (LevelManager.Instance.ActiveTile == null ||
            LevelManager.Instance.ActiveTile == this)
        {
            Deselect();
            LevelManager.Instance.SetActiveTile(this);
            return;
        }

        LevelManager.Instance.SetActiveTile(LevelManager.Instance.ActiveTile);
        Highlight();
    }

    void Deselect()
    {
        if (LevelManager.Instance.ActiveTile == null)
        {
            spriteRenderer.color = baseColor;
        }
    }
        

    void Highlight()
    {
        if (LevelManager.Instance.ActiveTile == null)
        {
            spriteRenderer.color = highlightColor;
        }
    }

    public void AddSpawnedObject(GameObject targetObject)
    {
        SpawnedObject = targetObject;
        SpawnedObject.SetActive(true);
        SpawnedObject.transform.SetParent(gameObject.transform);
    }
}
