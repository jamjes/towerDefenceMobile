using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamageable
{
    public enum ObstacleType { Tree, Stone };

    public ObstacleType Type; //{ private set; get; }

    [SerializeField] SpriteRenderer sprRenderer;
    [SerializeField] Sprite treeSprite;
    [SerializeField] Sprite stoneSprite;

    float _health;
    [SerializeField] TextMeshProUGUI _textLabel;

    void Start()
    {
        switch (Type)
        {
            case ObstacleType.Tree:
                _health = 25;
                sprRenderer.sprite = treeSprite;
                _textLabel.text = _health.ToString();
                break;

            case ObstacleType.Stone:
                _health = 50;
                sprRenderer.sprite = stoneSprite;
                _textLabel.text = _health.ToString();
                break;
        }
    }

    public void Heal()
    {
        throw new System.NotImplementedException();
    }

    public void Inflict(float amount)
    {
        _health -= amount;
        _textLabel.text = _health.ToString();

        if (_health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

    void OnMouseDown()
    {
        //Use Weapon power, instead of 1, as parameter.
        Inflict(1);
    }
}
