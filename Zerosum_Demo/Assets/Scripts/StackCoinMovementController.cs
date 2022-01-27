using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCoinMovementController : MonoBehaviour, IPooledObject
{
    private Transform connectedNode;

    public Transform ConnectedNode { set { connectedNode = value; } }

    private float coinSize;

    private int indexInStack;

    public int IndexInStack { set { indexInStack = value; } }

    void Update()
    {
        // transform.position = new Vector3(0f, 0f, coinSize * indexInStack);
    }
}
