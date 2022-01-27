using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapToPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private TextMeshProUGUI diamondCountText;

    [SerializeField]
    private TextMeshProUGUI upgradeButtonText;

    private int currentSceneIndex;

    private void OnEnable()
    {
        EventManager.OnStartStackUpgrade.AddListener(UpdateDiamondCountText);
    }

    private void OnDisable()
    {
        EventManager.OnStartStackUpgrade.RemoveListener(UpdateDiamondCountText);
    }

    void Start()
    {
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex;
        diamondCountText.text = GameManager.instance.CurrentDiamonds.ToString();
        upgradeButtonText.text = "Upgrade: " + GameManager.instance.CurrencyCostToUpgrade.ToString();
        levelText.text = "LEVEL " + currentSceneIndex;
    }

    private void UpdateDiamondCountText()
    {
        diamondCountText.text = GameManager.instance.CurrentDiamonds.ToString();
        upgradeButtonText.text = "Upgrade: " + GameManager.instance.CurrencyCostToUpgrade.ToString();
    }

    public void TapToPlayButton()
    {
        EventManager.OnTapToplayButtonPressed?.Invoke();
    }

    public void UpgradeButton()
    {
        EventManager.OnStartStackUpgrade?.Invoke();
    }
}
