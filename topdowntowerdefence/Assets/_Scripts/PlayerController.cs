using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas LandCanvas, PathCanvas;
    public Canvas activeCanvas;
    public Pointer pointer;
    Tile targetTile;

    private void OnEnable()
    {
        Tile.OnTileClick += SelectTarget;
    }

    private void OnDisable()
    {
        Tile.OnTileClick -= SelectTarget;
    }

    void SetActiveCanvas()
    {
        LandCanvas.gameObject.SetActive(false);
        PathCanvas.gameObject.SetActive(false);

        switch (targetTile.Type)
        {
            case Tile.TileType.Land:
                activeCanvas = LandCanvas;
                break;

            case Tile.TileType.Path:
                activeCanvas = PathCanvas;
                break;
        }

        activeCanvas.gameObject.SetActive(true);
    }


    void PermutePlayer()
    {
        transform.position = targetTile.transform.position;
    }

    void SelectTarget(Tile target)
    {
        targetTile = target;
        PermutePlayer();
        pointer.Show();
        SetActiveCanvas();
    }

    void DeselectTarget(Tile target)
    {
        targetTile = null;
        pointer.Hide();
        activeCanvas.gameObject.SetActive(false);
    }
}
