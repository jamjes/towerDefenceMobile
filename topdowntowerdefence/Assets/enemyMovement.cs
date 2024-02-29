using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private float speed = 1;
    public Rigidbody2D rb;
    public Transform target;
    private int pathIndex;

    public void Init()
    {
        pathIndex = 0;
        transform.position = LevelManager.Instance.path[pathIndex].position;
        pathIndex++;
        target = LevelManager.Instance.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= .01f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.Instance.path.Length)
            {
                gameObject.SetActive(false);
                return;
            }
            else
            {
                target = LevelManager.Instance.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
