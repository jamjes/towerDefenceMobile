using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Pointer : MonoBehaviour
{
    [SerializeField] Sprite targetterSprite, selectorSprite;
    SpriteRenderer sprRenderer;
    public enum PointerType { targetter, selector };
    PointerType type;

    private void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Tile.OnTileClick += SetPointerType;
    }

    private void OnDisable()
    {
        Tile.OnTileClick -= SetPointerType;
    }

    void SetPointerType(Tile target)
    {
        switch(target.Type)
        {
            case Tile.TileType.Obstacle:
                sprRenderer.sprite = targetterSprite;
                break;
            
            default:
                sprRenderer.sprite = selectorSprite;
                break;
        }
    }

    public void Hide()
    {
        sprRenderer.enabled = false;
    }

    public void Show()
    {
        sprRenderer.enabled = true;
    }
}
