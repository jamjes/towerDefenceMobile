using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    private void OnEnable()
    {
        GroundTile.OnTileHoverEnter += SetPointerLocationTo;
    }

    private void OnDisable()
    {
        GroundTile.OnTileHoverEnter -= SetPointerLocationTo;
    }

    void SetPointerLocationTo(GroundTile targetTile)
    {
        transform.position = targetTile.transform.position;
    }
}
