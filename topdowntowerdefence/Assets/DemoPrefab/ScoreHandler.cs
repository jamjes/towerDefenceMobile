using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    int gold = 300;

    private void OnEnable()
    {
        TileManager.OnUIScore += UpdateScore;
    }

    private void OnDisable()
    {
        TileManager.OnUIScore -= UpdateScore;
    }

    void Start()
    {
        label.text = gold.ToString();
    }

    public void UpdateScore(int value)
    {
        gold += value;
        label.text = gold.ToString();
    }
}
