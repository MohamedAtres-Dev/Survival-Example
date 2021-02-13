using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TileLoader 
{
    private const string TileName = "tile_0028";

    public static Tile GetBasicTile()
    {
        return GetTileByName(TileName);
    }


    private static Tile GetTileByName(string name)
    {
        return (Tile)Resources.Load(name, typeof(Tile));
    }
}
