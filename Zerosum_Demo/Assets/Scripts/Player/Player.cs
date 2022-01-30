using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private PlayerStackController playerStackController;

    private PlayerUIController playerUIController;

    private int startStack, currentCoins;

    public int StartStack { get { return startStack; } }

    public int CurrentCoins { get { return currentCoins; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.AddListener(UpgradeStartStack);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
        EventManager.OnCoinCollected.AddListener(UpdateCoinCount);
    }
    
    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.RemoveListener(UpgradeStartStack);
        EventManager.OnLevelFinish.RemoveListener(SavePlayerDataToJson);
        EventManager.OnCoinCollected.RemoveListener(UpdateCoinCount);
    }

    private void Start()
    {
        playerUIController = GetComponent<PlayerUIController>();
        playerStackController = GetComponent<PlayerStackController>();
        currentCoins =  GameManager.instance.CurrentCoins;
    }

    private void UpdateCoinCount()
    {
        currentCoins++;
        GameManager.instance.CurrentCoins = currentCoins;
    }

    private void UpgradeStartStack()
    {
        currentCoins =  GameManager.instance.CurrentCoins;

        if (currentCoins < GameManager.instance.CoinCostToUpgrade) return;

        playerStackController.IncreaseStack();
        playerUIController.IncreaseStackAmount();
        playerUIController.UpgradeDiamondCount();
        startStack++;
        GameManager.instance.StartStack = startStack;
    }

    private void SavePlayerDataToJson()
    {
        PlayerData playerData =  new PlayerData();
        playerData.startStack = 0;
        playerData.currentCoins = currentCoins;
        playerData.lastLevelIndex = LevelManager.instance.CurrentSceneIndex + 1;
        playerData.coinCostToUpgrade = GameManager.instance.CoinCostToUpgrade;
        DataManager.instace.Save(playerData);
    }

    private void LoadPlayerDataFromJson()
    {
        PlayerData playerData = DataManager.instace.Load();
        startStack = playerData.startStack;
        currentCoins = playerData.currentCoins;
        GameManager.instance.CurrentCoins = currentCoins;
        GameManager.instance.CoinCostToUpgrade = playerData.coinCostToUpgrade;
    }
}
