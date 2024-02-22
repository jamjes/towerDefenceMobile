using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreLabel;
    int _score;

    private void OnEnable()
    {
        Enemy.OnEnemyDeath += UpdateScore;
        Turret.OnTurrentDismantle += UpdateScore;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= UpdateScore;
        Turret.OnTurrentDismantle -= UpdateScore;
    }

    private void Start()
    {
        _scoreLabel.text = _score.ToString();
    }

    void UpdateScore(int amount)
    {
        _score += amount;
        _scoreLabel.text = _score.ToString();
    }
}
