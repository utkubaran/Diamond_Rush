using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    [SerializeField]
    private CharacterDataSO playerData;

    [SerializeField]
    private float stackSize;

    [SerializeField]
    private GameObject stackPrefab;

    [SerializeField]
    private int stackCount;             // todo remove

    [SerializeField]
    private int maxStackLimit;

    [SerializeField]
    private Transform stackBag;

    [SerializeField]
    private ObjectPooler objectPooler;

    private List<GameObject> stacks;

    // private int maxStackLimit;

    private void OnEnable()
    {
        EventManager.OnStackCollected.AddListener(IncreaseStack);
    }

    private void OnDisable()
    {
        EventManager.OnStackCollected.RemoveListener(IncreaseStack);
    }

    void Start()
    {
        stacks = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseStack();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DecreaseStack();
        }

        Debug.Log(stacks.Count);
    }

    private void IncreaseStack()
    {
        if (stackCount >= maxStackLimit) return;

        stackCount++;

        for (int i = stacks.Count; i < stackCount; i++)
        {
            GameObject obj = objectPooler.GetPooledObject();
            stacks.Add(obj);
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + stackSize * i);
            // obj.GetComponent<IPooledObject>().OnObjectSpawn();
            obj.transform.parent = stackBag;
        }
    }

    private void DecreaseStack()
    {
        if(stackCount <= 0) return;

        stackCount--;

        for (int i = stacks.Count - 1; i >= stackCount; i--)
        {
            stacks[i].gameObject.SetActive(false);
            stacks.RemoveAt(i);
        }
    }
}
