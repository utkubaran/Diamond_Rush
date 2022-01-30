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

    public int StartStack { get { return startStack; } set { startStack = value; } }

    public int CoinCostToUpgrade { get { return coinCostToUpgrade; } set { coinCostToUpgrade = value; } }

    private int collectedDiamonds;
    public int CollectedDiamonds { get { return collectedDiamonds; } }

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
        
        currentCoins -= coinCostToUpgrade;
        coinCostToUpgrade *= 2;
    }
}
