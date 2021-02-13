using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

//this class to hold objects will spawn && methods to spawn

[CreateAssetMenu(fileName = "PoolManager", menuName = "Singltons/Game Managers/Pool Manager")]
public class PoolManager : ScriptableObject
{

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    //private static void Init()
    //{
    //    _instance = Resources.Load<PoolManager>("PoolManager");
    //}


    public List<ItemToPool> allObjects;     //make a list of item to pool
    public bool isExpand;                   //check if its expandable
    private float transX = 110f;
    public List<GameObject> pooledObjects;  //this is the container


    [NonSerialized] public Transform spawnManagerTransform;
    //public GameObject testObject;

    public void StartPool()
    {
        pooledObjects = new List<GameObject>();

        //this to make the container
        foreach (ItemToPool item in allObjects)
        {
            for (int i = 0; i < item.size; i++)
            {
                GameObject go = Instantiate(item.pool);
                go.SetActive(false);
                pooledObjects.Add(go);
                go.transform.parent = spawnManagerTransform;
            }   
        }


    }
    
    //this to get an object fram a pool
    public GameObject GetPooledObject(string tag)
    {
        // control this to get random object to active again  = Done
        for (int i = 0; i < pooledObjects.Count; i++)
        { 
            if (pooledObjects[i].activeInHierarchy == false && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }


        if (isExpand)
        {
            GameObject[] randomObject = RandomList();

            // contol this to get a random object to instatiate again
            foreach (GameObject item in randomObject)
            {
                if (item.tag == tag)
                {
                    GameObject go = Instantiate(item);
                    go.SetActive(false);

                    pooledObjects.Add(go);
                    return go;
                }
            }

        }


        return null;
    }

    private GameObject[] RandomList()
    {
        //control this to random inital objects
        foreach (ItemToPool obj in allObjects)
        {
            pooledObjects.Add(obj.pool);
        }

        GameObject[] randomArray = pooledObjects.ToArray();

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            int k = UnityEngine.Random.Range(0, pooledObjects.Count);
            GameObject temp = randomArray[k];
            randomArray[k] = randomArray[i];
            randomArray[i] = temp;
        }
        return randomArray;

    }

}

[System.Serializable]
public class ItemToPool
{
    public GameObject pool;
    public int size;

}





