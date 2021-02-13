using UnityEngine;
using Pathfinding;

public class RecalculatePathManager : MonoBehaviour
{


    #region monobehvaiour
    private void OnEnable()
    {
        MapManager.generateEnemyPathEvent += UpdateGraphWithGridSize;
    }

    private void OnDisable()
    {
        MapManager.generateEnemyPathEvent -= UpdateGraphWithGridSize;
    }
    #endregion

    #region Methods
    private void UpdateGraphWithGridSize(int width , int height , float centerX , float centerY)
    {

        // This creates a Grid Graph
        GridGraph gg = AstarPath.active.data.gridGraph;

        // Setup a grid graph with some values

        float nodeSize = 1;

        centerX = centerX + 40;
        centerY = centerY + 50;

        gg.center = new Vector3(centerX, centerY, 0);

        // Updates internal size from the above values
        gg.SetDimensions(width, height, nodeSize);

        // Scans all graphs
        AstarPath.active.Scan();
    }

    #endregion


#if UNITY_EDITOR
    [SerializeField] private int width = 0;
    [SerializeField] private int height = 0;

    [ContextMenu("Make Graph")]
    public void MakeAnewGraph()
    {
        // This creates a Grid Graph
        GridGraph gg = AstarPath.active.data.gridGraph;

        // Setup a grid graph with some values
        
        float nodeSize = 1;

        gg.center = new Vector3(10, 0, 0);

        // Updates internal size from the above values
        gg.SetDimensions(width, height, nodeSize);

        // Scans all graphs
        AstarPath.active.Scan();
    }
#endif

}
