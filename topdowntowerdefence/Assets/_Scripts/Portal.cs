using System.Collections;
using TMPro;
using UnityEngine;

public class Portal : MonoBehaviour
{
    float duration = 10;
    [SerializeField] TextMeshProUGUI timerLabel;

    void Start()
    {
        StartCoroutine(Countdown(duration));
    }

    private void Update()
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
