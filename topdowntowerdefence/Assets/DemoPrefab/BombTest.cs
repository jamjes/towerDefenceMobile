using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTest : MonoBehaviour
{
    [SerializeField] Bomb bomb;
    [SerializeField] enemyMovement enemy;

    private void Start()
    {
        if (bomb != null) bomb.OnInstantiate(2f);
        if (enemy != null) enemy.Init();
    }
}
