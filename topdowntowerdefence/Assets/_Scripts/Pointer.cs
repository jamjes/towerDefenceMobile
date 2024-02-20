using System.Reflection;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Sprite targetterSprite, selectorSprite;
    SpriteRenderer sprRenderer;

    private void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPointerToSelector()
    {
        sprRenderer.sprite = selectorSprite;
    }

    public void SetPointerToTargetter()
    {
        sprRenderer.sprite = targetterSprite;
    }

    public void ShowPointer()
    {
        sprRenderer.enabled = true;
    }

    public void HidePointer()
    {
        sprRenderer.enabled = false;
    }

    public void SetState(bool state, BaseTile target)
    {
        //HideMenu();

        if (state == true)
        {
            ShowPointer();

            if (target.Type == BaseTile.TileType.Land)
            {
                //DisplayMenu(LandCanvas);
                SetPointerToSelector();
            }
            else if (target.Type == BaseTile.TileType.Path)
            {
                //DisplayMenu(PathCanvas);
                SetPointerToSelector();
            }
            else if (target.Type == BaseTile.TileType.Obstacle)
            {
                SetPointerToTargetter();
            }
        }
        else
        {
            HidePointer();
        }
    }

}
