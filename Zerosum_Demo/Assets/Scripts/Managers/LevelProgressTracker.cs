using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    public static LevelProgressTracker instance;

    private Transform finishLine, playerPos;

    private float distanceToFinish;

    private bool isFinished;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        finishLine = GameObject.FindGameObjectWithTag("Finish Line").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        isFinished = false;
    }

    private void Update()
    {
        distanceToFinish = Mathf.Abs(Vector3.Distance(finishLine.position, playerPos.position));

        if ((int)distanceToFinish == 0 && !isFinished)
        {
            isFinished = true;
            distanceToFinish = 100;
            EventManager.OnLevelFinish?.Invoke();
        }
    }
}
