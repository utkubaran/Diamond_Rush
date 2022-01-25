using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{    
    [SerializeField]
    private Animator animator;

    private float blendValue;
    public float BlendValue { set { blendValue = value; } }

    private bool isPlaying;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelStart.AddListener( () => animator.SetBool("isPlaying", true) );
        EventManager.OnLevelFinish.AddListener( () => isPlaying = false );
        EventManager.OnLevelFinish.AddListener(ActivateEndSceneAnimations);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelStart.RemoveListener( () => animator.SetBool("isPlaying", true) );
        EventManager.OnLevelFinish.RemoveListener( () => isPlaying = false );
        EventManager.OnLevelFinish.RemoveListener(ActivateEndSceneAnimations);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlaying)
        {
            animator.SetFloat("Blend", blendValue);
            return;
        }
    }

    private void ActivateEndSceneAnimations()
    {
        animator.SetBool("isPlaying", false);
        animator.SetBool("isEnd", true);
        return;
    }
}
