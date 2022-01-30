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
    private TextMeshProUGUI coinCountText;

    [SerializeField]
    private TextMeshProUGUI upgradeButtonText;

    private int currentSceneIndex;

    private void OnEnable()
    {
        EventManager.OnStartStackUpgrade.AddListener(UpgradeCoinCountText);
        EventManager.OnSceneStart.AddListener(UpgradeCoinCountText);
    }

    private void OnDisable()
    {
        EventManager.OnStartStackUpgrade.RemoveListener(UpgradeCoinCountText);
        EventManager.OnSceneStart.RemoveListener(UpgradeCoinCountText);
    }

    void Start()
    {
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex;
        coinCountText.text = GameManager.instance.CurrentCoins.ToString();
        upgradeButtonText.text = "Upgrade Start Stack for: " + GameManager.instance.CoinCostToUpgrade.ToString();
        levelText.text = "LEVEL " + currentSceneIndex;
    }

    private void UpgradeCoinCountText()
    {
        coinCountText.text = GameManager.instance.CurrentCoins.ToString();
        upgradeButtonText.text = "Upgrade Start Stack for: " + GameManager.instance.CoinCostToUpgrade.ToString();
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
