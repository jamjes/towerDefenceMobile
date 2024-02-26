using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GroundTile activeTile;
    public GameObject TurretPrefab;


    private void OnEnable()
    {
        GroundTile.OnTileSelect += SetActiveTile;
        UIButton.OnTurretSpawn += SpawnTurret;
        UIButton.OnTurretDismantle += DismantleTurret;
    }

    private void OnDisable()
    {
        GroundTile.OnTileSelect -= SetActiveTile;
        UIButton.OnTurretSpawn -= SpawnTurret;
        UIButton.OnTurretDismantle -= DismantleTurret;
    }

    void SetActiveTile(GroundTile targetTile)
    {
        if (activeTile == null)
        {
            activeTile = targetTile;
            activeTile.Select();
        }
        else if (activeTile == targetTile)
        {
            activeTile.Deselect();
            activeTile = null;
        }
        else
        {
            activeTile.Deselect();
            activeTile = targetTile;
            activeTile.Select();
        }
    }

    void SpawnTurret()
    {
        if (activeTile != null)
        {
            if (activeTile.spawnable == null)
            {
                GameObject turret = Instantiate(TurretPrefab, activeTile.transform.position, Quaternion.identity);
                activeTile.spawnable = turret;
            }
        }
    }

    void DismantleTurret()
    {
        if (activeTile != null)
        {
            if (activeTile.spawnable != null)
            {
                Destroy(activeTile.spawnable);
                activeTile.spawnable = null;
            }
        }
    }
}
