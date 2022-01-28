using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGamePanel : MonoBehaviour
{
    [SerializeField]
    private PlayerStackController playerStackController;

    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private TextMeshProUGUI coinText;

    private int currentSceneIndex, coinCount;

    private void OnEnable()
    {
        EventManager.OnCoinCollected.AddListener(UpgradeCoinAmount);
    }

    private void OnDisble()
    {
        EventManager.OnCoinCollected.RemoveListener(UpgradeCoinAmount);
    }

    void Start()
    {
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex;
        levelText.text = "LEVEL " + currentSceneIndex;
        coinCount = GameManager.instance.CurrentCoins;
        coinText.text = coinCount.ToString();
    }

    private void UpgradeCoinAmount()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }
}
