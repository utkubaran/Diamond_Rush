using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotationController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private Transform _transform;

    void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
