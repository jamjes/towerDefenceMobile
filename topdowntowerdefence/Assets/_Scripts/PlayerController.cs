using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas LandCanvas, PathCanvas;
    public Pointer pointer;
    Tile targetTile;
    public GameObject BombPrefab;
    public GameObject PortalPrefab;

    #region Solved_Methods
    private void OnEnable()
    {
        Tile.OnTileSelect += ToggleTargetTile;
    }

    private void OnDisable()
    {
        Tile.OnTileSelect -= ToggleTargetTile;
    }


    void MovePlayerTo(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    #endregion

    void ToggleTargetTile(Tile target)
    {
        HideAllMenus();

        if (targetTile != target)
        {
            targetTile = target;
            MovePlayerTo(targetTile.transform.position);
            pointer.SetState(true, targetTile);
            
            if (targetTile.Type == Tile.TileType.Land)
            {
                DisplayMenu(LandCanvas);
            }
            else if (targetTile.Type == Tile.TileType.Path)
            {
                DisplayMenu(PathCanvas);
            }
        }
        else
        {
            targetTile = null;
            pointer.SetState(false, targetTile);
        }
    }

    void DisplayMenu(Canvas target)
    {
        if (target == LandCanvas)
        {
            LandCanvas.gameObject.SetActive(true);
        }
        else if (target == PathCanvas)
        {
            PathCanvas.gameObject.SetActive(true);
        }
    }

    void HideAllMenus()
    {
        LandCanvas.gameObject.SetActive(false);
        PathCanvas.gameObject.SetActive(false);
    }

    public void SpawnBombAtTarget()
    {
        GameObject bomb = Instantiate(BombPrefab, targetTile.transform.position, Quaternion.identity);
        bomb.transform.parent = targetTile.transform;
        targetTile.SpawnedObject = bomb;
        ToggleTargetTile(targetTile);
    }

    public void SpawnPortalAtTarget()
    {
        GameObject portal = Instantiate(PortalPrefab, targetTile.transform.position, Quaternion.identity);
        portal.transform.parent = targetTile.transform;
        targetTile.SpawnedObject = portal;
        ToggleTargetTile(targetTile);
    }
}
