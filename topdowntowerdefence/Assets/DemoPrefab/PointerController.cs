using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    private void OnEnable()
    {
        GroundTile.OnTileHoverEnter += SetPointerLocationTo;
        PlayerTurret.OnTurretHoverEnter += SetPointerLocationTo;
    }

    private void OnDisable()
    {
        GroundTile.OnTileHoverEnter -= SetPointerLocationTo;
        PlayerTurret.OnTurretHoverEnter -= SetPointerLocationTo;
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
