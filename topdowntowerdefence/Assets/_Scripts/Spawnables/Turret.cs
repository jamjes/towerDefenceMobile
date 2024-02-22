using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour, IDamageable
{
    int _value;
    int _power;
    [SerializeField] Canvas UI;

    [SerializeField] SpriteRenderer sprRenderer;
    [SerializeField] Sprite baseSprite, upgradedSprite;
    
    public delegate void TurretDelegate(int value);
    public static event TurretDelegate OnTurrentDismantle;

    void Start()
    {
        sprRenderer.sprite = baseSprite;
        _power = 1;
        _value = 75;
        UI.gameObject.SetActive(false);
    }

    public void Heal()
    {
        throw new System.NotImplementedException();
    }

    public void Inflict(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void Kill()
    {
        if (OnTurrentDismantle != null)
        {
            OnTurrentDismantle(_value);
        }
        Destroy(this.gameObject);
    }

    public void Dismantle()
    {
        Kill();
    }

    void OnMouseDown()
    {
        UI.gameObject.SetActive(!UI.gameObject.activeSelf);
    }
    
    public void Upgrade(Button self)
    {
        sprRenderer.sprite = upgradedSprite;
        _power = 5;
        _value = 150;
        Destroy(self.gameObject);
        UI.gameObject.SetActive(false);
    }
}
