using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class MapManager : MonoBehaviour
{
    private Dictionary<int, Map.MapData> _maps;
    private int randomNum;

    private void Start()
    {
        _maps = GetComponent<MapLoader>().ReadMapData();

        SetUpTiles();
    }

    private void SetUpTiles()
    {
        var tilemap = GetComponentInChildren<Tilemap>();
        randomNum = Random.Range(0, _maps.Count - 1);
        var mapSize = _maps[randomNum].mapSize;
        var tile = TileLoader.GetBasicTile();
        var columns = mapSize.First();
        var rows = mapSize.Last();
  

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                tilemap.SetTile(pos, tile);
            }
        }
    }
}
