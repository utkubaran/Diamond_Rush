using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerUI;

    [SerializeField]
    private TextMeshProUGUI diamondText;

    [SerializeField]
    private Slider stackBar;

    private PlayerStackController playerStackController;

    private int diamondCount, maxStackLimit;

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => playerUI.SetActive(false) );
        EventManager.OnLevelStart.AddListener( () => playerUI.SetActive(true) );
        EventManager.OnDiamondCollected.AddListener(UpgradeDiamondCount);
        EventManager.OnHitObstacle.AddListener(DegreadeDiamondCount);
        EventManager.OnDiamondCollected.AddListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.AddListener(DecreaseStackAmount);
        EventManager.OnLevelFinish.AddListener( () => playerUI.SetActive(false) );
    }

    private void OnDisble()
    {
        EventManager.OnSceneStart.RemoveListener( () => playerUI.SetActive(false) );
        EventManager.OnLevelStart.RemoveListener( () => playerUI.SetActive(true) );
        EventManager.OnDiamondCollected.RemoveListener(UpgradeDiamondCount);
        EventManager.OnHitObstacle.RemoveListener(DegreadeDiamondCount);
        EventManager.OnDiamondCollected.RemoveListener(IncreaseStackAmount);
        EventManager.OnHitObstacle.RemoveListener(DecreaseStackAmount);
        EventManager.OnLevelFinish.RemoveListener( () => playerUI.SetActive(false) );
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
        maxStackLimit = playerStackController.MaxStackLimit;
    }
    
    public void UpgradeDiamondCount()
    {
        if (diamondCount == maxStackLimit) return;
        
        diamondCount++;
        diamondText.text = diamondCount.ToString();
    }

    private void DegreadeDiamondCount()
    {
        if (diamondCount == 0) return;

        diamondCount--;
        diamondText.text = diamondCount.ToString();
    }

    public void IncreaseStackAmount()
    {
        stackBar.value = playerStackController.StackPerct;
    }

    private void DecreaseStackAmount()
    {
        stackBar.value = playerStackController.StackPerct;
    }
}
