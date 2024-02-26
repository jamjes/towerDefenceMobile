using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public delegate void UIButtonDelegate();
    public static event UIButtonDelegate OnTurretSpawn;
    public static event UIButtonDelegate OnTurretDismantle;
    
    public void SpawnTurretAtTarget()
    {
        if (OnTurretSpawn != null)
        {
            OnTurretSpawn();
        }
    }

    public void DismantleTurretAtTarget()
    {
        if (OnTurretDismantle != null)
        {
            OnTurretDismantle();
        }
    }
}
