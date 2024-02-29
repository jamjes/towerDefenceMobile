using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour, ISpawnable, IDamageable
{
    [SerializeField] TextMeshProUGUI _timerLabel;
    bool _started = false;
    float timeReference;
    [SerializeField] CircleCollider2D circleCollider;

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
        //RaycastHit2D[] col = Physics2D.BoxCastAll(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.zero);

        RaycastHit2D[] cols = Physics2D.CircleCastAll(circleCollider.bounds.center, circleCollider.radius, Vector2.zero);

        foreach (var col in cols)
        {
            if (col.collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Inflict(10);
            }
        }

        Destroy(this.gameObject);
    }

    IEnumerator BeginCountdown(float duration)
    {
        _started = true;
        timeReference = duration;
        yield return new WaitForSeconds(duration);
        Kill();
    }

    void Update()
    {
        if (_started == true)
        {
            timeReference -= Time.deltaTime;
            _timerLabel.text = timeReference.ToString("0.00");
        }
    }

    public void OnInstantiate(float duration)
    {
        _timerLabel.text = duration.ToString("0.00");
        StartCoroutine(BeginCountdown(duration));
    }
}
