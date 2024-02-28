using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GroundTile ActiveTile; //{ private set; get; }
    [SerializeField] Canvas buildMenu, trapMenu;
    public Canvas ActiveMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        
        Destroy(gameObject);
    }

    public void SetActiveTile(GroundTile targetTile)
    {
        if (ActiveTile == targetTile)
        {
            ActiveTile = null;
            ActiveMenu.gameObject.SetActive(false);
            return;
        }

        ActiveTile = targetTile;

        if (ActiveTile.Type == GroundTile.TileType.Grass)
        {
            ActiveMenu = buildMenu;
        }
        else
        {
            ActiveMenu = trapMenu;
        }

        ActiveMenu.transform.position = new Vector3(targetTile.transform.position.x, targetTile.transform.position.y + .5f);
        ActiveMenu.gameObject.SetActive(true);
    }
}
