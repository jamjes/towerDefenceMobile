using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GroundTile activeTile;
    public GameObject TurretPrefab;

    public delegate void UIScoreDelegate(int value);
    public static event UIScoreDelegate OnUIScore;


    private void OnEnable()
    {
        GroundTile.OnTileSelect += SetActiveTile;
        //UIButton.OnTurretSpawn += SpawnTurret;
        //UIButton.OnTurretDismantle += DismantleTurret;
    }

    private void OnDisable()
    {
        GroundTile.OnTileSelect -= SetActiveTile;
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
}
