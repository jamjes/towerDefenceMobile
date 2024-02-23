using System.Collections;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour, ISpawnable, IDamageable
{
    [SerializeField] TextMeshProUGUI _timerLabel;
    bool _started = false;
    float timeReference;
    
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
