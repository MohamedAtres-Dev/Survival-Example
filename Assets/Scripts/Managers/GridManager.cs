using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Enemy get;
    [SerializeField] private float gridRow = 5f;
    [SerializeField] private float gridColumn = 10f;
    [SerializeField] private GameObject cellPrefab = default;

    // Start is called before the first frame update
    void Start()
    {
        //TODO : Read from JSON File num of rows and columns
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int z = 0; z < gridRow; z++)
        {
            for (int x = 0; x < gridColumn; x++)
            {
                GameObject cell = Instantiate(cellPrefab, transform);

                cell.transform.position = new Vector3(x, 0, z);
            }
        }

        transform.position = new Vector3(-(gridColumn / 2 + 0.5f), 0f, -(gridRow / 2 - 0.5f));
    }
}
