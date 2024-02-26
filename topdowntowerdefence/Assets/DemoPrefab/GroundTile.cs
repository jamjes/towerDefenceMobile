using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprRenderer;
    [SerializeField] Color baseColor, selectColor;
    bool selected;

    public delegate void GroundTileDelegate(GroundTile tile);
    public static event GroundTileDelegate OnTileHoverEnter;
    public static event GroundTileDelegate OnTileSelect;

    public GameObject spawnable;

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
        if (OnTileHoverEnter != null)
        {
            OnTileHoverEnter(this);
        }
    }

    void OnMouseDown()
    {
        if (OnTileSelect != null)
        {
            OnTileSelect(this);
        }
    }

    public void Select()
    {
        sprRenderer.color = selectColor;
        selected = true;
    }

    public void Deselect()
    {
        sprRenderer.color = baseColor;
        selected = false;
    }
}
