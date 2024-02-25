using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float interval;
    private float timeReference;
    public EnemyPool objPool;
    public Transform spawnPoint;

    private void Start()
    {
        timeReference = interval;
    }

    private void Update()
    {
        timeReference -= Time.deltaTime;

        if (timeReference <= 0)
        {
            GameObject request = objPool.GetPooledObject();
            
            if (request != null)
            {
                request.transform.position = spawnPoint.transform.position;
                request.GetComponent<enemyMovement>().Init();
                request.SetActive(true);
            }

            timeReference = interval;
        }
    }
}
