using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovementController : MonoBehaviour
{
    [SerializeField]
    private float frequency;

    [SerializeField]
    private float magnitude;

    [SerializeField]
    private float offset;

    private Vector3 startPos;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        startPos = _transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _transform.position = startPos + Vector3.left * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
}
