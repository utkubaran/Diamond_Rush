using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool isCoin = other.gameObject.GetComponent<Coin>();
        bool isDiamond = other.gameObject.GetComponent<Diamond>();
        bool isObstacle = other.gameObject.GetComponent<Obstacle>();

        if (isCoin)
        {
            EventManager.OnCoinCollected?.Invoke();
            other.GetComponent<ICollectable>().OnCollected();
            Debug.Log("I worked!");
        }
        else if (isDiamond)
        {
            EventManager.OnDiamondCollected?.Invoke();
            other.GetComponent<ICollectable>().OnCollected();
        }
        else if (isObstacle)
        {
            EventManager.OnHitObstacle?.Invoke();
        }
    }
}
