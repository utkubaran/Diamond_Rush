using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapToPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex;
        levelText.text = "LEVEL " + currentSceneIndex;
    }

    public void TapToPlayButton()
    {
        EventManager.OnTapToplayButtonPressed?.Invoke();
    }

    public void UpgradeButton()
    {
        EventManager.OnStackLimitUpgrade?.Invoke();
    }
}
