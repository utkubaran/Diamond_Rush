using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int startStack;

    [SerializeField]
    private int coinCostToUpgrade;

    public int StartStack { get { return startStack; } }

    public int CoinCostToUpgrade { get { return coinCostToUpgrade; } }

    [SerializeField]
    private int currentCoins;
    public int CurrentCoins { get { return currentCoins; } set { currentCoins = value; } }

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

    private void Update()
    {
        Debug.Log(currentCoins);
    }

    private void UpdateDiamondCount()
    {
        if (currentCoins < coinCostToUpgrade) return;
        
        currentCoins -= coinCostToUpgrade;
        coinCostToUpgrade *= 2;
    }
}
