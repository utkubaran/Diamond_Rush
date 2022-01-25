using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character Data", menuName = "Player Data")]
public class CharacterDataSO : ScriptableObject
{
    public int MaxStackLimit;

    public int stackUpgradeAmount;
}
