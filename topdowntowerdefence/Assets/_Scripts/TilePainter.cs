using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TilePainter : MonoBehaviour
{
    public enum TileType { Land, Path };
    public enum LandType { TopLeft, Top, TopRight, Left, Center, Right, BottomLeft, Bottom, BottomRight };
    public enum PathType { TopLeft, TopRight, BottomLeft,  BottomRight, Horizontal, Vertical };

    public TileType tileType;
    public LandType landType;
    public PathType pathType;

    public Sprite[] landSprites;
    public Sprite[] pathSprites;

    public SpriteRenderer sprRenderer;
    

    void Update()
    {
        if (tileType == TileType.Land)
        {
            switch (landType)
            {
                case LandType.TopLeft:
                    if (sprRenderer.sprite != landSprites[0])
                    {
                        sprRenderer.sprite = landSprites[0];
                    }
                    break;
                case LandType.Top:
                    if (sprRenderer.sprite != landSprites[1])
                    {
                        sprRenderer.sprite = landSprites[1];
                    }
                    break;
                case LandType.TopRight:
                    if (sprRenderer.sprite != landSprites[2])
                    {
                        sprRenderer.sprite = landSprites[2];
                    }
                    break;
                case LandType.Left:
                    if (sprRenderer.sprite != landSprites[3])
                    {
                        sprRenderer.sprite = landSprites[3];
                    }
                    break;
                case LandType.Center:
                    if (sprRenderer.sprite != landSprites[4])
                    {
                        sprRenderer.sprite = landSprites[4];
                    }
                    break;
                case LandType.Right:
                    if (sprRenderer.sprite != landSprites[5])
                    {
                        sprRenderer.sprite = landSprites[5];
                    }
                    break;
                case LandType.BottomLeft:
                    if (sprRenderer.sprite != landSprites[6])
                    {
                        sprRenderer.sprite = landSprites[6];
                    }
                    break;
                case LandType.Bottom:
                    if (sprRenderer.sprite != landSprites[7])
                    {
                        sprRenderer.sprite = landSprites[7];
                    }
                    break;
                case LandType.BottomRight:
                    if (sprRenderer.sprite != landSprites[8])
                    {
                        sprRenderer.sprite = landSprites[8];
                    }
                    break;
            }
        }
        else
        {
            switch(pathType)
            {
                case PathType.TopLeft:
                    if (sprRenderer.sprite != pathSprites[0])
                    {
                        sprRenderer.sprite = pathSprites[0];
                    }
                    break;
                case PathType.TopRight:
                    if (sprRenderer.sprite != pathSprites[1]) 
                    {
                        sprRenderer.sprite = pathSprites[1];
                    }
                    break;
                case PathType.BottomLeft:
                    if (sprRenderer.sprite != pathSprites[2]) 
                    {
                        sprRenderer.sprite = pathSprites[2];
                    }
                    break;
                case PathType.BottomRight:
                    if (sprRenderer.sprite != pathSprites[3]) 
                    {
                        sprRenderer.sprite = pathSprites[3];
                    }
                    break;
                case PathType.Horizontal:
                    if (sprRenderer.sprite != pathSprites[4]) 
                    {
                        sprRenderer.sprite = pathSprites[4];
                    }
                    break;
                case PathType.Vertical:
                    if (sprRenderer.sprite != pathSprites[5]) 
                    {
                        sprRenderer.sprite = pathSprites[5];
                    }
                    break;
            }
        }
    }
}
