using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour, IPooledObject
{
    private Transform playerPos;

    private Transform referencePos;

    public Transform ReferencePos { set { referencePos = value;} }

    private int index;

    public int Index { set { index = value; } }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, referencePos.position.x, Time.deltaTime * 20f), 0f, referencePos.position.z + 2.5f);
    }

    public void OnObjectSpawn(int ind)
    {
        return; 
        
        // this.index = ind;
        // playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
