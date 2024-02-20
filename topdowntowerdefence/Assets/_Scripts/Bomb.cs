using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    float duration = 7;
    [SerializeField] TextMeshProUGUI timerLabel;
    
    void Start()
    {
        StartCoroutine(Countdown(duration));
    }

    void Update()
    {
        duration -= Time.deltaTime;
        timerLabel.text = ((int)duration).ToString();
    }

    public IEnumerator Countdown(float time)
    {
        yield return new WaitForSeconds(time);
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
