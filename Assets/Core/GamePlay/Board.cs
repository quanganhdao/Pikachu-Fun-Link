using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Board : MonoBehaviour
{
    private Tile[,] tiles;

    [SerializeField] private Transform container;

    private List<Tile> tilesNeedToBeSetUp = new List<Tile>();

    public void Initialize(int sizeX, int sizeY, float offset, Tile tilePrefab, ItemConfig config)
    {
        tiles = new Tile[sizeX, sizeY];
        InitializeTileList(sizeX, sizeY, tilePrefab);
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                if (tilesNeedToBeSetUp.Count == 0)
                {
                    container.position = new Vector3(-(sizeX) / 2, -sizeY / 2, 0);
                    return;
                };

                if (tiles[x, y].IsItemSetUp()) continue;

                ItemSO itemSO = config.GetRandomItem();
                tiles[x, y].SetItem(itemSO);

                var result = tilesNeedToBeSetUp.Remove(tiles[x, y]);

                int randomIndex = Random.Range(0, tilesNeedToBeSetUp.Count);
                var secondTile = tilesNeedToBeSetUp[randomIndex];
                secondTile.SetItem(itemSO);
                tilesNeedToBeSetUp.Remove(secondTile);

            }
        }
    }

    public void InitializeTileList(int x, int y, Tile tilePrefab)
    {

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Vector3 position = new Vector3(i, j, 0);
                Tile tile = Instantiate(tilePrefab, position, Quaternion.identity, container);
                tiles[i, j] = tile;
                tiles[i, j].SetPosInGrid(i, j);
                tilesNeedToBeSetUp.Add(tiles[i, j]);
            }
        }
        // Debug.Log(tileNeedToBeSetUp.Count);
    }

    public Tile[,] GetTiles()
    {
        return tiles;
    }

    public void GetRandonPosInGrid(int x, int y)
    {

    }
}
