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

    private int collectedDiamonds;

    public int StartStack { get { return startStack; } set { startStack = value; } }

    public int CoinCostToUpgrade { get { return coinCostToUpgrade; } set { coinCostToUpgrade = value; } }

    public int CollectedDiamonds { get { return collectedDiamonds; } }

    [SerializeField]
    private int currentCoins;
    public int CurrentCoins { get { return currentCoins; } set { currentCoins = value; } }

    private void OnEnable()
    {
        EventManager.OnDiamondCollected.AddListener( () => collectedDiamonds++ );
        EventManager.OnStartStackUpgrade.AddListener(UpdateCoinCount);
    }

    private void OnDisable()
    {
        EventManager.OnDiamondCollected.RemoveListener( () => collectedDiamonds++ );
        EventManager.OnStartStackUpgrade.RemoveListener(UpdateCoinCount);
    }

    private void Awake()
    {
        if (instance != null)   return;

        instance = this;
    }

    private void Start()
    {
        collectedDiamonds = 0;
        Debug.Log(Application.persistentDataPath);
    }

    private void UpdateCoinCount()
    {
        if (currentCoins < coinCostToUpgrade) return;
        Debug.Log(coinCostToUpgrade);
        
        currentCoins -= coinCostToUpgrade;
        coinCostToUpgrade *= 2;
    }
}
