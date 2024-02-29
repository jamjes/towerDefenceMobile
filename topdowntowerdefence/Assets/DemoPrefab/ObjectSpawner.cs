using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public delegate void ObjectSpawnerDelegate(int index);
    public static event ObjectSpawnerDelegate OnSpawnRequest;

    public void SpawnObject(int index)
    {
        if (OnSpawnRequest != null)
        {
            OnSpawnRequest(index);
            LevelManager.Instance.SetActiveTile(null);
        }
    }
}
