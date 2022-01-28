using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int startStack, currentCoins;

    public int StartStack { get { return startStack; } }

    public int CurrentCoins { get { return currentCoins; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.AddListener(UpgradeStartStack);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
    }
    
    private void OnDisable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.AddListener(UpgradeStartStack);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
    }

    private void UpgradeStartStack()
    {
        if (currentCoins < GameManager.instance.CoinCostToUpgrade) return;

        EventManager.OnDiamondCollected?.Invoke();
        startStack++;
        currentCoins = GameManager.instance.CurrentCoins;
        // GameManager.instance.CurrentCoins = currentCoins;
    }

    private void SavePlayerDataToJson()
    {
        PlayerData playerData =  new PlayerData();
        playerData.startStack = startStack;
        playerData.currentCoins = currentCoins;
        playerData.lastLevelIndex = LevelManager.instance.CurrentSceneIndex + 1;
        DataManager.instace.Save(playerData);
    }

    private void LoadPlayerDataFromJson()
    {
        PlayerData playerData = DataManager.instace.Load();
        startStack = playerData.startStack;
        currentCoins = playerData.currentCoins;
        GameManager.instance.CurrentCoins = currentCoins;
    }
}
