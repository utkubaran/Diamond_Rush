using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    [SerializeField]
    private ObjectPooler objectPooler;

    private Player player;

    private PlayerAnimationController animationController;

    private List<GameObject> stacks;

    private int maxStackLimit = 20, stackAmount, startStack;

    private float stackPerct;
    public float StackPerct { get { return stackPerct; } }

    private void OnEnable()
    {
        EventManager.OnDiamondCollected.AddListener(IncreaseStack);
        EventManager.OnHitObstacle.AddListener(DecreaseStack);
    }

    private void OnDisable()
    {
        EventManager.OnDiamondCollected.RemoveListener(IncreaseStack);
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
        stackAmount = player.StartStack;
        stackPerct = (float)stackAmount / (float)maxStackLimit;
    }

    private void IncreaseStack()
    {
        if (stackAmount >= maxStackLimit) return;

        stackAmount++;

        for (int i = stacks.Count; i < stackAmount; i++)
        {
            GameObject obj = objectPooler.GetPooledObject();
            stacks.Add(obj);
            // obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + i * 1.5f);
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
