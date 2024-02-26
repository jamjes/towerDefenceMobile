using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public delegate void TurretUIDelegate(PlayerTurret turret);
    public static event TurretUIDelegate OnTurretHoverEnter;

    void OnMouseEnter()
    {
        if (OnTurretHoverEnter != null)
        {
            OnTurretHoverEnter(this);
        }
    }
}
