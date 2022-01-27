using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    [SerializeField]
    private CharacterDataSO playerData;

    [SerializeField]
    private Transform stackBag1;

    [SerializeField]
    private Transform stackBag2;

    [SerializeField]
    private ObjectPooler objectPooler;

    private Player player;

    private PlayerAnimationController animationController;

    private List<GameObject> stacks;

    private int stackAmount, maxStackLimit;

    private float stackPerct;
    public float StackPerct { get { return stackPerct; } }

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
        player = GetComponent<Player>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    void Start()
    {
        stacks = new List<GameObject>();
        maxStackLimit = player.MaxStackLimit;
    }

    private void IncreaseStack()
    {
        if (stackAmount >= maxStackLimit) return;

        stackAmount++;

        for (int i = stacks.Count; i < stackAmount; i++)
        {
            GameObject obj = objectPooler.GetPooledObject();
            stacks.Add(obj);
            stackPerct = (float)stackAmount / (float)maxStackLimit;
            animationController.BlendValue = stackPerct;
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
            stackPerct = (float)stackAmount / (float)maxStackLimit;
            animationController.BlendValue = stackPerct;
        }
    }
}
