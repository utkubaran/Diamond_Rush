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
    private Transform stackPos;

    [SerializeField]
    private Transform poolParent;

    [SerializeField]
    private float coinSize;

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
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.parent = poolParent == null ? transform : poolParent; 
            obj.transform.position = new Vector3(stackPos.position.x, stackPos.position.y, stackPos.position.z + i * coinSize);
            obj.GetComponent<StackDiamondMovementController>().ConnectedNode = i == 0 ? stackPos.transform : pooledObjects[i - 1].transform;
            obj.GetComponent<StackDiamondMovementController>().IndexInStack = i;
            obj.GetComponent<StackDiamondMovementController>().StackPos = stackPos;
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
