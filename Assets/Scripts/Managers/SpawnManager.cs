using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private PoolManager _poolManager;
    [SerializeField] private Transform playerTransform = default;
    [SerializeField] private float spawnTime = 4f;

    #endregion

    #region monobehaviour

    void Start()
    {
        _poolManager.spawnManagerTransform = transform;
        _poolManager.StartPool();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
    #endregion

    #region Methods

    private void Spawn()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 1: 
                GetEnemyFromPool("JumperEnemy");
                break;
            case 2:
                GetEnemyFromPool("MovableEnemy");
                break;
        }
    }

    private void GetEnemyFromPool(string name)
    {
        GameObject enemy = _poolManager.GetPooledObject(name);
        enemy.transform.position = playerTransform.position + new Vector3(Random.Range(-10f , 10f) , Random.Range(-10f, 10f), 0);
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);
    }
    #endregion
}
