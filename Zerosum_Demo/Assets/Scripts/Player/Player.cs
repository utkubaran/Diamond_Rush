using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int maxStackLimit, currentDiamonds;

    public int MaxStackLimit { get { return maxStackLimit; } }

    public int CurrentDiamonds { get { return currentDiamonds; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerData);
        EventManager.OnStackLimitUpgrade.AddListener(UpgradeMaxStackLimit);
        EventManager.OnLevelFinish.AddListener(SavePlayerData);
    }
    
    private void OnDisable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerData);
        EventManager.OnStackLimitUpgrade.AddListener(UpgradeMaxStackLimit);
        EventManager.OnLevelFinish.AddListener(SavePlayerData);
    }

    private void Start()
    {
        
    }

    private void UpgradeMaxStackLimit()
    {
        maxStackLimit++;
    }

    private void SavePlayerData()
    {
        maxStackLimit = DataManager.instace.playerData.maxStackLimit;
        currentDiamonds = DataManager.instace.playerData.currentDiamonds;
        DataManager.instace.Save();
    }

    private void LoadPlayerData()
    {
        DataManager.instace.Load();
        maxStackLimit = DataManager.instace.playerData.maxStackLimit;
        currentDiamonds = DataManager.instace.playerData.currentDiamonds;
    }
}
