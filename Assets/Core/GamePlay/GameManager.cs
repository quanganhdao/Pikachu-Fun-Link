using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private int sizeX;
    [SerializeField] private int sizeY;
    [SerializeField] private float offset;
    [SerializeField] private Board board;
    [SerializeField] private ItemConfig itemConfig;

    private Tile currentTile;
    private void Awake()
    {
        if (board != null)
        {
            board.Initialize(sizeX, sizeY, offset, tilePrefab, itemConfig);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckConnectability(Tile firstTile, Tile secondTile)
    {

    }


    public void OnTileClick(Tile clickedTile)
    {
        if (currentTile != null)
        {
            CheckConnectability(currentTile, clickedTile);
        }
        currentTile?.UnPick();
        currentTile = clickedTile;
        currentTile.Pick();
    }
}
