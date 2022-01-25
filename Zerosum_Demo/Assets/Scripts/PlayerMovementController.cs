using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Vector3 movementDirection, movementVector;

    private float horizontalPos, verticalPos;

    private bool isPlaying;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelFail.AddListener( () => isPlaying = false );
        EventManager.OnLevelFinish.AddListener( () => isPlaying = false );
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelFail.RemoveListener( () => isPlaying = false );
        EventManager.OnLevelFinish.RemoveListener( () => isPlaying = false );
    }

    private void Awake()
    {
        inputController = GetComponent<PlayerInputController>();
        _transform = this.transform;
    }

    private void Start()
    {
        isPlaying = true;       // todo remove after events are enabled
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
            // verticalPos = movementSpeed * Time.deltaTime + _transform.position.z;
            // _transform.position = new Vector3(horizontalPos, _transform.position.y, verticalPos);
        }

        verticalPos = movementSpeed * Time.deltaTime + _transform.position.z;
        _transform.position = new Vector3(horizontalPos, _transform.position.y, verticalPos);
    }
}
