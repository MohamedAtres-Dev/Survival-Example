using System;

[Serializable]
public class Map 
{
    public MapData[] mapsdata;

    [Serializable]
    public class MapData
    {
        public int mapNum;
        public int[] mapSize;
    }
}

