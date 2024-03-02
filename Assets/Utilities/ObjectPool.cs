using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    [System.Serializable]
    public class ObjectPoolData
    {
        public GameObject prefab;
        public int initialPoolSize = 10;
    }

    public List<ObjectPoolData> objectPools;

    private Dictionary<GameObject, List<GameObject>> pooledObjects;

    private void Awake()
    {
        Instance = this;

        pooledObjects = new Dictionary<GameObject, List<GameObject>>();

        foreach (ObjectPoolData poolData in objectPools)
        {
            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < poolData.initialPoolSize; i++)
            {
                GameObject obj = Instantiate(poolData.prefab, transform);
                obj.SetActive(false);
                objectPool.Add(obj);
            }

            pooledObjects.Add(poolData.prefab, objectPool);
        }
    }

    private void Start()
    {
        
    }

    public GameObject GetObjectFromPool(GameObject prefab)
    {
        if (pooledObjects.ContainsKey(prefab))
        {
            List<GameObject> objectPool = pooledObjects[prefab];

            foreach (GameObject obj in objectPool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            // If no inactive objects are found in the pool, create a new one
            GameObject newObj = Instantiate(prefab);
            objectPool.Add(newObj);
            return newObj;
        }
        else
        {
            Debug.LogWarning("Object pool for prefab " + prefab.name + " not found.");
            return null;
        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}