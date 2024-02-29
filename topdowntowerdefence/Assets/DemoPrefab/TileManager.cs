using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GroundTile activeTile;

    public delegate void UIScoreDelegate(int value);
    public static event UIScoreDelegate OnUIScore;

    [SerializeField] GameObject bombPrefab, portalPrefab, turretPrefab;

    private void OnEnable()
    {
        GroundTile.OnTileSelect += SetActiveTile;
        ObjectSpawner.OnSpawnRequest += SpawnChildObject;
        //UIButton.OnTurretSpawn += SpawnTurret;
        //UIButton.OnTurretDismantle += DismantleTurret;
    }

    private void OnDisable()
    {
        GroundTile.OnTileSelect -= SetActiveTile;
        ObjectSpawner.OnSpawnRequest -= SpawnChildObject;
        //UIButton.OnTurretSpawn -= SpawnTurret;
        //UIButton.OnTurretDismantle -= DismantleTurret;
    }
    void SetActiveTile(GroundTile targetTile)
    {
        if (activeTile == targetTile)
        {
            activeTile = null;
            return;
        }

        activeTile = targetTile;
    }

    void SpawnChildObject(int objectIndex)
    {
        if (activeTile.SpawnedObject != null)
        {
            Debug.Log("Tile Occupied");
            return;
        }

        switch (objectIndex)
        {
            case 1:
                GameObject turret = Instantiate(turretPrefab, activeTile.transform.position, Quaternion.identity);
                activeTile.SetSpawnedObject(turret);
                break;
            case 2:
                GameObject bomb = Instantiate(bombPrefab, activeTile.transform.position, Quaternion.identity);
                bomb.TryGetComponent(out Bomb bombFunction);
                bombFunction.OnInstantiate(7f);
                activeTile.SetSpawnedObject(bomb);
                break;
            case 3:
                GameObject portal = Instantiate(portalPrefab, activeTile.transform.position, Quaternion.identity);
                portal.TryGetComponent(out Portal portalFunction);
                portalFunction.OnInstantiate(12f);
                activeTile.SetSpawnedObject(portal);
                break;
        }
    }
}
