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
        Debug.Log(pooledAmount);

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);

            if (poolParent == null) return;

            obj.transform.parent = poolParent;
            obj.transform.position = new Vector3(poolParent.position.x, poolParent.position.y, poolParent.position.z + i * 0.25f);
            obj.GetComponent<StackCoinMovementController>().ConnectedNode = i == 0 ? poolParent.transform : pooledObjects[i - 1].transform;
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                Debug.Log("çalisiyor");
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
