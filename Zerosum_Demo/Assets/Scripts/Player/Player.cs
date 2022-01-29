using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int startStack, currentCoins, currentDiamonds;

    public int StartStack { get { return startStack; } }

    public int CurrentCoins { get { return currentCoins; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.AddListener(UpgradeStartStack);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
        EventManager.OnCoinCollected.AddListener(UpdateCoinCount);
        // EventManager.OnDiamondCollected.AddListener( () => collectedDiamonds++ );
    }
    
    private void OnDisable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.AddListener(UpgradeStartStack);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
        EventManager.OnCoinCollected.RemoveListener(UpdateCoinCount);
        // EventManager.OnDiamondCollected.RemoveListener( () => collectedDiamonds++ );
    }

    private void UpdateCoinCount()
    {
        currentCoins++;
        GameManager.instance.CurrentCoins = currentCoins;
    }

    private void UpgradeStartStack()
    {
        if (currentCoins < GameManager.instance.CoinCostToUpgrade) return;

        Debug.Log("works");
        startStack++;
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
