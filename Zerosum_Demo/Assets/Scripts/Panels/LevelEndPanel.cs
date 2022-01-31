using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelEndPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI collectedCoinsText;

    private int collectedDiamonds;

    void Start()
    {
        collectedCoinsText.text = "Collected Coins: " + GameManager.instance.CollectedCoins.ToString();
    }

    public void NextLevelButton()
    {
        EventManager.OnNextLevelButtonPressed?.Invoke();
    }
}
