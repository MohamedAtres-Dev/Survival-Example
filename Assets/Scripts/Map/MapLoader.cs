using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    private const string MapsPath = "MapsData";
    public Dictionary<int , Map.MapData> ReadMapData()
    {
        var jsonFile = Resources.Load(MapsPath, typeof(TextAsset)) as TextAsset;
        if (jsonFile == null)
        {
            throw new ApplicationException("Maps file is not accessible");
        }

        var loadedData = JsonUtility.FromJson<Map>(jsonFile.text);

        return loadedData.mapsdata.ToDictionary(map => map.mapNum, map => map);
    }
}
