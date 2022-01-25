using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public enum PlayerState { Idle, Running, RunningWithFullBag, Dancing }
    
    [SerializeField]
    private Animator animator;

    private PlayerState currentState;
    public PlayerState CurrentState { set { currentState = value; } }

    private float blendValue;
    public float BlendValue { set { blendValue = value; } }

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => currentState = PlayerState.Running );
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => currentState = PlayerState.Running );
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentState = PlayerState.Idle;
    }

    void Update()
    {
        animator.SetFloat("Blend", blendValue);
        // ChangeAnimationState();

    }

    private void ChangeAnimation()
    {
            switch (currentState)
        {
            case PlayerState.Idle:
                animator?.SetBool("isWalking", false);
                break;
            case PlayerState.Running:
                animator?.SetBool("isWalking", true);
                break;
            case PlayerState.RunningWithFullBag:
                animator?.SetBool("isWalking", true);
                break;
            default:
                Debug.LogError("NO ANIMATION STATE!");
                break;
        }
    }
}
