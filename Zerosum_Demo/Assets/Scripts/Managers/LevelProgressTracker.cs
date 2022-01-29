using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    public static LevelProgressTracker instance;

    private Transform finishLine, playerPos;

    private int collectedDiamonds, collectedCoins;

    private float distanceToFinish;

    private bool isFinished;

    private void OnEnable()
    {
        EventManager.OnCoinCollected.AddListener( () => collectedCoins++ );
        EventManager.OnDiamondCollected.AddListener( () => collectedDiamonds++ );
    }

    private void OnDisable()
    {
        EventManager.OnCoinCollected.RemoveListener( () => collectedCoins++ );
        EventManager.OnDiamondCollected.RemoveListener( () => collectedDiamonds++ );
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        finishLine = GameObject.FindGameObjectWithTag("Finish Line").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        // collectedDiamonds = DataManager.instace.playerData.currentDiamonds;
        collectedDiamonds = 0;
        collectedCoins = 0;
        isFinished = false;
    }

    private void Update()
    {
        distanceToFinish = Mathf.Abs(Vector3.Distance(finishLine.position, playerPos.position));

        if ((int)distanceToFinish == 0 && !isFinished)
        {
            Debug.Log("level finished!");
            isFinished = true;
            distanceToFinish = 100;
            EventManager.OnLevelFinish?.Invoke();
        }
    }
}
