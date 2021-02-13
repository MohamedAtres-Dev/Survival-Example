using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using UnityEngine.Events;

public class MapManager : MonoBehaviour
{
    #region Fields
    private Dictionary<int, Map.MapData> _maps;
    private int randomNum;

    //Invoke this event after set the tiles to spawn player and start the game
    public event UnityAction mapIsLoaded = delegate { };

    //Invoke this to recalculate path for Enemy AI
    public static event UnityAction<int, int, float, float> generateEnemyPathEvent = delegate { };
    #endregion

    #region Monobehaviour
    private void Start()
    {
        _maps = GetComponent<MapLoader>().ReadMapData();

        SetUpTiles();
    }

    #endregion

    #region Private Methods
    private void SetUpTiles()
    {
        var tilemap = GetComponentInChildren<Tilemap>();
        var tile = TileLoader.GetBasicTile();

        randomNum = Random.Range(1, _maps.Count - 1);

        var mapSize = _maps[randomNum].mapSize;
        var columns = mapSize.First();
        var rows = mapSize.Last();

        tilemap.gameObject.transform.position = new Vector3(-columns / 2, -rows / 2);
        

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                tilemap.SetTile(pos, tile);
            }
        }

        mapIsLoaded.Invoke();
        generateEnemyPathEvent.Invoke(rows, columns, -columns / 2, -rows / 2);
    }
    #endregion
}
