using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool isStack = other.GetComponent<Stack>();
        bool isCurrency = other.GetComponent<Currency>();

        if (isStack)
        {
            EventManager.OnStackCollected?.Invoke();
            other.GetComponent<ICollectable>().OnCollected();
        }
        else if (isCurrency)
        {
            EventManager.OnCurrencyCollected?.Invoke();
            other.GetComponent<ICollectable>().OnCollected();
        }


    }
}
