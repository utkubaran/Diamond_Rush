using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnSceneStart = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnSceneFinish = new UnityEvent();
    #endregion

    #region  Player Events
    public static UnityEvent OnHitObstacle = new UnityEvent();
    #endregion

    #region  Collectable Events
    public static UnityEvent OnCoinCollected = new UnityEvent();
    public static UnityEvent OnDiamondCollected = new UnityEvent();
    #endregion

    #region Button Events
    public static UnityEvent OnTapToplayButtonPressed = new UnityEvent();
    public static UnityEvent OnNextLevelButtonPressed = new UnityEvent();
    #endregion

    #region Upgrade Events
    public static UnityEvent OnStartStackUpgrade = new UnityEvent();
    #endregion
}

