using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour, ICollectable
{
    public void OnCollected()
    {
        Destroy(this.gameObject);
    }
}
