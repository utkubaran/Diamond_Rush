using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelEndPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI collectedDiamondText;

    private int collectedDiamonds;

    void Start()
    {
        collectedDiamondText.text = "Collected Diamonds: " + GameManager.instance.CollectedDiamonds.ToString();
    }

    public void NextLevelButton()
    {
        EventManager.OnNextLevelButtonPressed?.Invoke();
    }
}
