using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int defaultMaxStackLimit;

    [SerializeField]
    private int currencyCostToUpgrade;

    [SerializeField]
    private int stackLimitUpgradeAmount;

    public int DefaultMaxStackLimit { get { return defaultMaxStackLimit; } }

    public int CurrencyCostToUpgrade { get { return currencyCostToUpgrade; } }

    public int StackLimitUpgradeAmount { get { return stackLimitUpgradeAmount; } }

    [SerializeField]
    private int currentDiamonds;
    public int CurrentDiamonds { get { return currentDiamonds; } set { currentDiamonds = value; } }

    private void Awake()
    {
        instance = this;
    }
}
