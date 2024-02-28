using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    private void OnEnable()
    {
        //GroundTile.OnTileSelect += SetPointerLocationTo;
    }

    private void OnDisable()
    {
        //GroundTile.OnTileSelect -= SetPointerLocationTo;
    }

    void SetPointerLocationTo(GroundTile targetTile)
    {
        transform.position = targetTile.transform.position;
    }

    void SetPointerLocationTo(PlayerTurret targetTurret)
    {
        transform.position = targetTurret.transform.position;
    }
}
