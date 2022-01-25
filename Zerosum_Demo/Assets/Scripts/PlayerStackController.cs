using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    [SerializeField]
    private CharacterDataSO playerData;

    [SerializeField]
    private int stackCount;

    [SerializeField]
    private int maxStackLimit;

    [SerializeField]
    private Transform stackBag1;

    [SerializeField]
    private Transform stackBag2;

    [SerializeField]
    private ObjectPooler objectPooler;

    private PlayerAnimationController animationController;

    private List<GameObject> stacks;

    private float stackPerct;
    public float StackPerct { get { return stackPerct; } }

    // private int maxStackLimit;

    private void OnEnable()
    {
        EventManager.OnStackCollected.AddListener(IncreaseStack);
    }

    private void OnDisable()
    {
        EventManager.OnStackCollected.RemoveListener(IncreaseStack);
    }

    private void Awake()
    {
        animationController = GetComponent<PlayerAnimationController>();
    }

    void Start()
    {
        stacks = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseStack();            // todo remove
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DecreaseStack();            // todo remove
        }
    }

    private void IncreaseStack()
    {
        if (stackCount >= maxStackLimit) return;

        stackCount++;

        for (int i = stacks.Count; i < stackCount; i++)
        {
            GameObject obj = objectPooler.GetPooledObject();
            stacks.Add(obj);
            animationController.BlendValue = (float)stackCount / (float)maxStackLimit;
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
            animationController.BlendValue = (float)stackCount / (float)maxStackLimit;
        }
    }
}
