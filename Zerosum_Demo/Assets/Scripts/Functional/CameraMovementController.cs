using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    private Vector3 endSceneCamOffset = new Vector3(0f, 2.5f, -15f);

    private CinemachineVirtualCamera vCam;

    private void OnEnable()
    {
        EventManager.OnLevelFinish.AddListener(MoveCameraToEndScene);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener(MoveCameraToEndScene);
    }

    private void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void MoveCameraToEndScene()
    {
        DOTween.To( () => vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, x => vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = x, endSceneCamOffset, 2.5f);
    }
}
