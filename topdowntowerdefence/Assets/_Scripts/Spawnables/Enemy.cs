using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] float _health;
    [SerializeField] int _value;

    public delegate void EnemyDelegate(int value);
    public static event EnemyDelegate OnEnemyDeath;

    public void Heal()
    {
        throw new System.NotImplementedException();
    }

    public void Inflict(float amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath(_value);
        }

        Destroy(this.gameObject);
    }

    void OnMouseDown()
    {
        //Use weapon power, instead of 1, as parameter.
        Inflict(1);
    }
}

