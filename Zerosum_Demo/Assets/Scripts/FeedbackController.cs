using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FeedbackController : MonoBehaviour
{
    [SerializeField]
    private float impulseMagnitude;
    private CinemachineImpulseSource impulseSource;

    private void OnEnable()
    {
        EventManager.OnHitObstacle.AddListener(CameraShake);
    }

    private void OnDisable()
    {
        EventManager.OnHitObstacle.RemoveListener(CameraShake);
    }

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void CameraShake()
    {
        impulseSource.GenerateImpulse(Vector3.one * impulseMagnitude);
    }
}
