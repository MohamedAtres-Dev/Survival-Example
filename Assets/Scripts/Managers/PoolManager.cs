using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//this class to hold objects will spawn && methods to spawn

[CreateAssetMenu(fileName = "PoolManager", menuName = "Singltons/Game Managers/Pool Manager")]
public class PoolManager : ScriptableObject
{
    private static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        _instance = Resources.Load<PoolManager>("PoolManager");
    }



    public List<ItemToPool> allObjects;     //make a list of item to pool
    public List<ItemToPool> allObjectsUI;
    public bool isExpand;                   //check if its expandable
    private float transX = 110f;
    public List<GameObject> pooledObjects;
    public List<GameObject> pooledObjectsUI;  //this is the container

    public Transform levelManager;
    //public GameObject testObject;

    public void StartPool()
    {
        pooledObjects = new List<GameObject>();

        //this to make the container
        foreach (ItemToPool item in allObjects)
        {
            GameObject go = Instantiate(item.pool);
            go.SetActive(false);
            pooledObjects.Add(go);
        }


    }
    public void StartPoolUI(GameObject obj)
    {
        pooledObjectsUI = new List<GameObject>();

        transX = 110f;
        //this to make the container
        foreach (ItemToPool item in allObjectsUI)
        {
            for (int i = 0; i < item.size; i++)
            {
                GameObject go = Instantiate(item.pool);
                go.SetActive(false);
                go.transform.SetParent(obj.transform);
                //make a special transform for each icon here
                go.GetComponent<RectTransform>().position = new Vector2(transX, 0);
                pooledObjectsUI.Add(go);
                transX += 200f;
            }


        }


    }

    //this to get an object fram a pool
    public GameObject GetPooledObject(string tag)
    {
        // control this to get random object to active again  = Done
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            int k = GenerateRandom();
            if (pooledObjects[k].activeInHierarchy == false && pooledObjects[k].tag == tag)
            {
                return pooledObjects[k];
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

    public GameObject GetPooledObjectUI(string name)
    {
        // control this to get random object to active again  = Done
        for (int i = 0; i < pooledObjectsUI.Count; i++)
        {
            if (pooledObjectsUI[i].name != name && pooledObjectsUI[i].activeInHierarchy == false)
            {
                pooledObjectsUI[i].name = name;
            }


            if (pooledObjectsUI[i].activeInHierarchy == false && pooledObjectsUI[i].name == name)
            {
                return pooledObjectsUI[i];
            }

            if (pooledObjectsUI[i].activeInHierarchy == true && pooledObjectsUI[i].name == name)
            {
                return pooledObjectsUI[i];
            }


        }

        /*
        if (isExpand)
        {
            // contol this to get a random object to instatiate again
            foreach (ItemToPool item in allObjectsUI)
            {
                GameObject go = Instantiate(item.pool);
                go.SetActive(false);
                go.transform.SetParent(obj.transform);
                pooledObjectsUI.Add(go);
                return go;
            }

        }
        */

        return null;
    }

    private int GenerateRandom()
    {
        int j = Random.Range(0, pooledObjects.Count);
        return j;
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
            int k = Random.Range(0, pooledObjects.Count);
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





