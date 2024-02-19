using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private void OnEnable()
    {
        Tile.SnapPointer += Permute;
    }

    private void OnDisable()
    {
        Tile.SnapPointer -= Permute;
    }

    void Permute(Vector3 pos)
    {
        transform.position = pos;
    }
}
