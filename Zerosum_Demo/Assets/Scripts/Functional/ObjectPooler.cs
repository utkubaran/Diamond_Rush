using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    public GameObject pooledObject;
    
    [SerializeField]
    private int pooledAmount;

    [SerializeField]
    private Transform poolParent;

    private List<GameObject> pooledObjects = new List<GameObject> ();

    void Start()
    {
        CreateObjectPool();
    }

    private void CreateObjectPool()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            // obj.transform.parent = transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);

            if (poolParent == null) return;

            obj.transform.parent = poolParent;
            obj.transform.position = new Vector3(poolParent.position.x, poolParent.position.y + 0.15f * i, poolParent.position.z);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }

        return null;
    }

    public void SendObjectToPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy) return;

            pooledObjects[i].SetActive(false);
        }
    }
}
