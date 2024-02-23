using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas LandCanvas, PathCanvas;
    public Pointer pointer;
    Tile targetTile;
    public GameObject BombPrefab;
    public GameObject PortalPrefab;
    public GameObject TurretPrefab;

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
            
            if (targetTile.gfx.tileType == TilePainter.TileType.Land)
            {
                DisplayMenu(LandCanvas);
            }
            else if (targetTile.gfx.tileType == TilePainter.TileType.Path)
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

    public void SpawnObjectAtTarget(int spawnIndex)
    {
        GameObject obj;

        if (spawnIndex == 0)
        {
            obj = Instantiate(BombPrefab, targetTile.transform.position, Quaternion.identity);
            obj.GetComponent<Bomb>().OnInstantiate(7);
        }
        else if (spawnIndex == 1)
        {
            obj = Instantiate(PortalPrefab, targetTile.transform.position, Quaternion.identity);
            obj.GetComponent<Portal>().OnInstantiate(12);
        }
        else
        {
            obj = Instantiate(TurretPrefab, targetTile.transform.position, Quaternion.identity);
        }

        obj.transform.parent = targetTile.transform;
        targetTile.SpawnedObject = obj;
        ToggleTargetTile(targetTile);
    }
}
