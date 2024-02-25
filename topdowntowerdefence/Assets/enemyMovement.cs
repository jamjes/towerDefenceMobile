using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private float speed = 5;
    public Rigidbody2D rb;
    public Transform target;
    private int pathIndex;

    public void Init()
    {
        pathIndex = 0;
        transform.position = levelManager.Instance.path[pathIndex].position;
        pathIndex++;
        target = levelManager.Instance.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= .01f)
        {
            pathIndex++;

            if (pathIndex == levelManager.Instance.path.Length)
            {
                gameObject.SetActive(false);
                return;
            }
            else
            {
                target = levelManager.Instance.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
