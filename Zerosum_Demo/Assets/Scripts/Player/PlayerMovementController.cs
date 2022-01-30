using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;        // todo refactor with scriptable object

    [SerializeField]
    private float swerveSpeed;

    [SerializeField]
    private float xBorder;

    [SerializeField]
    [Range(0f, 0.25f)]private float movementThreshold;

    private PlayerInputController inputController;

    private Transform _transform;

    private Vector3 movementDirection;

    private float horizontalPos, verticalPos;

    private bool isPlaying;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelFinish.AddListener( () => isPlaying = false );
        EventManager.OnLevelFinish.AddListener(EndSceneMovement);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelFinish.RemoveListener( () => isPlaying = false );
        EventManager.OnLevelFinish.RemoveListener(EndSceneMovement);
    }

    private void Awake()
    {
        inputController = GetComponent<PlayerInputController>();
        _transform = this.transform;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (inputController == null || !isPlaying) return;

        movementDirection = inputController.MovementDirection;

        if (movementDirection.magnitude >= movementThreshold)
        {
            horizontalPos = Mathf.Clamp(movementDirection.x * swerveSpeed * Time.deltaTime + _transform.position.x, -xBorder, +xBorder);
        }

        verticalPos = movementSpeed * Time.deltaTime + _transform.position.z;
        _transform.position = new Vector3(horizontalPos, _transform.position.y, verticalPos);
    }

    private void EndSceneMovement()
    {
        transform.DOMove(transform.position + Vector3.forward * 5f, 2.5f);
    }
}
