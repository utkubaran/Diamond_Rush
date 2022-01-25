using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnSceneStart = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnSceneFinish = new UnityEvent();
    #endregion

    #region  Player Events
    #endregion

    #region  Collectible Events
    public static UnityEvent OnStackCollected = new UnityEvent();
    public static UnityEvent OnCurrencyCollected = new UnityEvent();
    #endregion

    #region Button Events
    public static UnityEvent OnPlayButtonPressed = new UnityEvent();
    public static UnityEvent OnNextLevelButtonPressed = new UnityEvent();
    public static UnityEvent OnTryAgainButtonPressed = new UnityEvent();
    #endregion
}

