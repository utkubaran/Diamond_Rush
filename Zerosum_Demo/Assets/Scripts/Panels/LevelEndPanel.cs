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

    private void OnEnable()
    {
        EventManager.OnDiamondCollected.AddListener( () => collectedDiamonds++ );
        EventManager.OnSceneFinish.AddListener( () => collectedDiamondText.text = collectedDiamonds.ToString() );
    }

    private void OnDisable()
    {
        EventManager.OnDiamondCollected.RemoveListener( () => collectedDiamonds++ );
        EventManager.OnSceneFinish.RemoveListener( () => collectedDiamondText.text = collectedDiamonds.ToString() );
    }

    void Start()
    {
        collectedDiamonds = 0;
    }

    public void NextLevelButton()
    {
        EventManager.OnNextLevelButtonPressed?.Invoke();
    }
}
