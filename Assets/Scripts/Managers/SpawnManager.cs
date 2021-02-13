using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private PoolManager _poolManager;
    // Start is called before the first frame update
    void Start()
    {
        _poolManager.spawnManagerTransform = transform;
        _poolManager.StartPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
