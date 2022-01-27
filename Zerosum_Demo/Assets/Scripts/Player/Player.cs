using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int maxStackLimit, currentDiamonds, stackLimitUpgradeAmount, currencyCostToUpgrade;

    public int MaxStackLimit { get { return maxStackLimit; } }

    public int CurrentDiamonds { get { return currentDiamonds; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStackLimitUpgrade.AddListener(UpgradeMaxStackLimit);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
    }
    
    private void OnDisable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStackLimitUpgrade.AddListener(UpgradeMaxStackLimit);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
    }

    private void UpgradeMaxStackLimit()
    {
        maxStackLimit += stackLimitUpgradeAmount;
        currentDiamonds -= currencyCostToUpgrade;
        GameManager.instance.CurrentDiamonds = currentDiamonds;
    }

    private void SavePlayerDataToJson()
    {
        PlayerData playerData =  new PlayerData();
        playerData.maxStackLimit = maxStackLimit;
        playerData.currentDiamonds = currentDiamonds;
        playerData.lastLevelIndex = LevelManager.instance.CurrentSceneIndex + 1;
        DataManager.instace.Save(playerData);
    }

    private void LoadPlayerDataFromJson()
    {
        PlayerData playerData = DataManager.instace.Load();
        maxStackLimit = playerData.maxStackLimit;
        currentDiamonds = playerData.currentDiamonds;
        GameManager.instance.CurrentDiamonds = currentDiamonds;
    }
}
