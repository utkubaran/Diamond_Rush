using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int startStack, currentDiamonds;

    public int StartStack { get { return startStack; } }

    public int CurrentDiamonds { get { return currentDiamonds; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.AddListener(UpgradeMaxStackLimit);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
    }
    
    private void OnDisable()
    {
        EventManager.OnSceneStart.AddListener(LoadPlayerDataFromJson);
        EventManager.OnStartStackUpgrade.AddListener(UpgradeMaxStackLimit);
        EventManager.OnLevelFinish.AddListener(SavePlayerDataToJson);
    }

    private void UpgradeMaxStackLimit()
    {
        EventManager.OnCoinCollected?.Invoke();
        startStack++;
        GameManager.instance.CurrentDiamonds = currentDiamonds;
    }

    private void SavePlayerDataToJson()
    {
        PlayerData playerData =  new PlayerData();
        playerData.startStack = startStack;
        playerData.currentDiamonds = currentDiamonds;
        playerData.lastLevelIndex = LevelManager.instance.CurrentSceneIndex + 1;
        DataManager.instace.Save(playerData);
    }

    private void LoadPlayerDataFromJson()
    {
        PlayerData playerData = DataManager.instace.Load();
        startStack = playerData.startStack;
        currentDiamonds = playerData.currentDiamonds;
        GameManager.instance.CurrentDiamonds = currentDiamonds;
    }
}
