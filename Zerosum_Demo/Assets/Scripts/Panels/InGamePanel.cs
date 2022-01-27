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
    private TextMeshProUGUI diamondText;

    [SerializeField]
    private Slider stackBar;

    private int currentSceneIndex, diamondCount;

    private void OnEnable()
    {
        EventManager.OnCoinCollected.AddListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.AddListener(DecreaseStackAmount);
        EventManager.OnDiamondCollected.AddListener(UpdateCurrencyAmount);
    }

    private void OnDisble()
    {
        EventManager.OnCoinCollected.RemoveListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.RemoveListener(DecreaseStackAmount);
        EventManager.OnDiamondCollected.RemoveListener(UpdateCurrencyAmount);
    }

    void Start()
    {
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex;
        levelText.text = "LEVEL " + currentSceneIndex;
        diamondCount = GameManager.instance.CurrentDiamonds;
        diamondText.text = diamondCount.ToString();
        stackBar.value = playerStackController.StackPerct;
    }

    private void UpdateCurrencyAmount()
    {
        diamondCount++;
        diamondText.text = diamondCount.ToString();
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
