using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundTile : MonoBehaviour
{
    public enum TileType { Grass, Path };
    [SerializeField] TileType type;
    public GameObject SpawnedObject { private set; get; }
    SpriteRenderer spriteRenderer;
    [SerializeField] Color baseColor, altColor;

    //bool selected;

    public delegate void GroundTileDelegate(GroundTile tile);
    public static event GroundTileDelegate OnTileHoverEnter;
    public static event GroundTileDelegate OnTileHoverExit;
    public static event GroundTileDelegate OnTileSelect;
    public static event GroundTileDelegate OnTileDeselect;

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

    void OnMouseEnter()
    {
        if (LevelManager.Instance.ActiveTile == null)
        {
            Highlight();
        }
    }

    void OnMouseExit() 
    {
        if (LevelManager.Instance.ActiveTile == null)
        {
            Deselect();
        } 
    }
    

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Deselect();
        
        if (LevelManager.Instance.ActiveTile == null)
        {
            if (OnTileSelect != null)
            {
                OnTileSelect(this);
            }

            LevelManager.Instance.SetActiveTile(this);
            return;
        }

        Highlight();
        LevelManager.Instance.SetActiveTile(null);

        if (OnTileDeselect != null)
        {
            OnTileDeselect(this);
        }
    }

    void Deselect()
    {
        spriteRenderer.color = baseColor;
    }
        

    void Highlight()
    {
        spriteRenderer.color = altColor;
    }

    public TileType GetTileType()
    {
        return type;
    }

    public void SetSpawnedObject(GameObject target)
    {
        SpawnedObject = target;
    }
}
