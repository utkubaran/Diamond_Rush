using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int startStack;

    [SerializeField]
    private int currencyCostToUpgrade;

    public int StartStack { get { return startStack; } }

    public int CurrencyCostToUpgrade { get { return currencyCostToUpgrade; } }

    [SerializeField]
    private int currentDiamonds;
    public int CurrentDiamonds { get { return currentDiamonds; } set { currentDiamonds = value; } }

    private void OnEnable()
    {
        EventManager.OnStartStackUpgrade.AddListener(UpdateDiamondCount);
    }

    private void OnDisable()
    {
        EventManager.OnStartStackUpgrade.RemoveListener(UpdateDiamondCount);
    }

    private void Awake()
    {
        if (instance != null)   return;

        instance = this;
    }

    private void UpdateDiamondCount()
    {
        currentDiamonds -= currencyCostToUpgrade;
        currencyCostToUpgrade *= 2;
    }
}
