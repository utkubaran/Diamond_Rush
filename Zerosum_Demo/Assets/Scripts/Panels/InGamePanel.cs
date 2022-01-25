using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : MonoBehaviour
{
    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text diamondText;

    [SerializeField]
    private Text stackText;

    private int currentSceneIndex, stackCount, diamondCount;

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
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex + 1;
        levelText.text = "Level " + currentSceneIndex;
        diamondText.text = diamondCount.ToString();
        stackText.text = stackCount.ToString();
    }

    private void UpdateCurrencyAmount()
    {
        diamondCount++;
        diamondText.text = diamondCount.ToString();
    }

    private void IncreaseStackAmount()
    {
        stackCount++;
        stackText.text = stackCount.ToString();
    }

    private void DecreaseStackAmount()
    {
        stackCount--;
        stackText.text = stackCount.ToString();
    }
}
