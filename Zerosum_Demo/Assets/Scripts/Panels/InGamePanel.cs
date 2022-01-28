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

    [SerializeField]
    private Slider stackBar;

    private int currentSceneIndex, coinCount;

    private void OnEnable()
    {
        EventManager.OnDiamondCollected.AddListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.AddListener(DecreaseStackAmount);
        EventManager.OnCoinCollected.AddListener(UpgradeCoinAmount);
    }

    private void OnDisble()
    {
        EventManager.OnDiamondCollected.RemoveListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.RemoveListener(DecreaseStackAmount);
        EventManager.OnCoinCollected.RemoveListener(UpgradeCoinAmount);
    }

    void Start()
    {
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex;
        levelText.text = "LEVEL " + currentSceneIndex;
        coinCount = GameManager.instance.CurrentCoins;
        coinText.text = coinCount.ToString();
        stackBar.value = playerStackController.StackPerct;
    }

    private void UpgradeCoinAmount()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }

    private void IncreaseStackAmount()
    {
        stackBar.value = playerStackController.StackPerct;
    }

    private void DecreaseStackAmount()
    {
        stackBar.value = playerStackController.StackPerct;
    }
}
