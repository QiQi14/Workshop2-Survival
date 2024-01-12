using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileNode : MonoBehaviour
{

    [SerializeField]
    private GameObject highlightTile;

    public bool Walkable;
    public int terrainCost;
    public TileType tileType;

    public int x,y;

    private void OnMouseEnter()
    {
        highlightTile.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlightTile.SetActive(false);
    }
}
