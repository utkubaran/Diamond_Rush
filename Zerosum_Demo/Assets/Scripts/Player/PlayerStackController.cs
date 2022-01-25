using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    [SerializeField]
    private CharacterDataSO playerData;

    [SerializeField]
    private int stackAmount;

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
        EventManager.OnCoinCollected.AddListener(IncreaseStack);
        EventManager.OnHitObstacle.AddListener(DecreaseStack);
    }

    private void OnDisable()
    {
        EventManager.OnCoinCollected.RemoveListener(IncreaseStack);
        EventManager.OnHitObstacle.RemoveListener(DecreaseStack);
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
        if (stackAmount >= maxStackLimit) return;

        stackAmount++;

        for (int i = stacks.Count; i < stackAmount; i++)
        {
            GameObject obj = objectPooler.GetPooledObject();
            stacks.Add(obj);
            animationController.BlendValue = (float)stackAmount / (float)maxStackLimit;
        }
    }

    private void DecreaseStack()
    {
        if(stackAmount <= 0) return;

        stackAmount--;

        for (int i = stacks.Count - 1; i >= stackAmount; i--)
        {
            stacks[i].gameObject.SetActive(false);
            stacks.RemoveAt(i);
            animationController.BlendValue = (float)stackAmount / (float)maxStackLimit;
        }
    }
}
