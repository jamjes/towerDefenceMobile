using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Countdown());
    }
    
    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
