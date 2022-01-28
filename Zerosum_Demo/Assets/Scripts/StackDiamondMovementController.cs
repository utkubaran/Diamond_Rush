using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDiamondMovementController : MonoBehaviour
{
    [SerializeField]
    private float coinSize;

    private float nodeSpeed = 20f;

    private Transform connectedNode, stackPos;
    public Transform ConnectedNode { set { connectedNode = value; } }

    public Transform StackPos { set { stackPos = value; } }

    private int indexInStack;

    public int IndexInStack { set { indexInStack = value; } }

    void Update()
    {
        /*
        Vector3 pos1 = new Vector3(transform.position.x, transform.position.y, stackPos.position.z + coinSize * indexInStack);
        Vector3 pos2 = new Vector3(connectedNode.position.x, transform.position.y, stackPos.position.z + coinSize * indexInStack);
        Vector3 pos = Vector3.Slerp(pos1, pos2, Time.deltaTime * nodeSpeed);
        transform.position = pos;
        */

        float xPos = Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * nodeSpeed);
        transform.position = new Vector3(xPos, transform.position.y, stackPos.position.z + indexInStack * coinSize);
    }
}
