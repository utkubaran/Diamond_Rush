using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCoinMovementController : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private float coinSize;

    private float nodeSpeed = 5f;

    private Transform connectedNode, stackPos;
    public Transform ConnectedNode { set { connectedNode = value; } }

    public Transform StackPos { set { stackPos = value; } }

    private int indexInStack;

    public int IndexInStack { set { indexInStack = value; } }

    void FixedUpdate()
    {
        connectedNode.transform.name = "bla blac";

        float xPos = Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * nodeSpeed);
        transform.position = new Vector3(xPos, transform.position.y, stackPos.position.z + indexInStack * 1.5f);
    }
}
