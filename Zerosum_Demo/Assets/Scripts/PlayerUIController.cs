using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI diamondText;

    [SerializeField]
    private Slider stackBar;

    private PlayerStackController playerStackController;

    private int diamondCount;

    private void OnEnable()
    {
        EventManager.OnDiamondCollected.AddListener(UpgradeDiamondCount);
        EventManager.OnHitObstacle.AddListener(DegreadeDiamondCount);
        EventManager.OnDiamondCollected.AddListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.AddListener(DecreaseStackAmount);
    }

    private void OnDisble()
    {
        EventManager.OnDiamondCollected.RemoveListener(UpgradeDiamondCount);
        EventManager.OnHitObstacle.RemoveListener(DegreadeDiamondCount);
        EventManager.OnDiamondCollected.RemoveListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.RemoveListener(DecreaseStackAmount);
    }

    private void Awake()
    {
        playerStackController = GetComponent<PlayerStackController>();
    }

    private void Start()
    {
        diamondCount = playerStackController.StackAmount;
        diamondText.text = diamondCount.ToString();
        stackBar.value = playerStackController.StackPerct;
    }
    
    private void UpgradeDiamondCount()
    {
        diamondCount++;
        diamondText.text = diamondCount.ToString();
    }

    private void DegreadeDiamondCount()
    {
        diamondCount--;
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
