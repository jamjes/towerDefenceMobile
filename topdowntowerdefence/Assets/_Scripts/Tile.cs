using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType { Grass, Path, Tree, Boulder};
    [SerializeField] TileType type;
    GameObject healthBar;

    public delegate void PointerDelegate(Vector3 position);
    public static event PointerDelegate SnapPointer;

    public delegate void TileDelegate();
    public static event TileDelegate TileEffector;

    private void Start()
    {
        healthBar = transform.GetChild(0).gameObject;
        healthBar.SetActive(false);
    }

    void OnMouseOver()
    {
        if (SnapPointer != null)
        {
            SnapPointer(transform.position);
        }
    }

    void OnMouseDown()
    {
        if (TileEffector != null) TileEffector();
        Select();
    }

    public void Deselect()
    {
        if (type == TileType.Boulder || type == TileType.Tree) healthBar.SetActive(false);
    }

    void Select()
    {
        if (type == TileType.Boulder || type == TileType.Tree) healthBar.SetActive(true);
    }
}
