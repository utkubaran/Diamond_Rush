using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    public static LevelProgressTracker instance;

    private int collectedDiamonds, collectedCoins;

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
        collectedDiamonds = DataManager.instace.playerData.currentDiamonds;
        // collectedDiamonds = 0;
        collectedCoins = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            EventManager.OnLevelFinish?.Invoke();
        }
    }
}
