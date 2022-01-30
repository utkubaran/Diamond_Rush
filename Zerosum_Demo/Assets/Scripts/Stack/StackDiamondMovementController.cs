using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDiamondMovementController : MonoBehaviour
{
    [SerializeField]
    private float coinSize;

    private float nodeSpeed = 25f;

    private Transform connectedNode, stackPos;
    public Transform ConnectedNode { set { connectedNode = value; } }

    public Transform StackPos { set { stackPos = value; } }

    private int indexInStack;

    public int IndexInStack { set { indexInStack = value; } }

    void Update()
    {
        float xPos = Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * nodeSpeed);
        transform.position = new Vector3(xPos, transform.position.y, stackPos.position.z + indexInStack * coinSize);
    }
}
