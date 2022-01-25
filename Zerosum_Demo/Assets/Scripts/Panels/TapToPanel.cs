using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPanel : MonoBehaviour
{
    [SerializeField]
    private Text levelText;

    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = LevelManager.instance.CurrentSceneIndex + 1;
        levelText.text = "Level " + currentSceneIndex;
    }

    public void TapToPlayButton()
    {
        EventManager.OnTapToplayButtonPressed?.Invoke();
    }
}
