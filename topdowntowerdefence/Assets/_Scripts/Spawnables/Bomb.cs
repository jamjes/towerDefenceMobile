using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour, IDamageable
{
    [SerializeField] TextMeshProUGUI _timerLabel;
    bool _started = false;
    [SerializeField] float _duration;
    float timeReference;

    void Start()
    {
        OnInstantiate(7);
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
        Destroy(this.gameObject);
    }

    void OnMouseDown()
    {
        if (_started == false)
        {
            StartCoroutine(BeginCountdown(_duration));
        }

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

    void OnInstantiate(float duration)
    {
        this._duration = duration;
        _timerLabel.text = _duration.ToString("0.00");
    }
}
