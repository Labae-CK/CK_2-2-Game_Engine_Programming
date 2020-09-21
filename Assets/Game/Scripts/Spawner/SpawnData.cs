using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "Data/SpawnData", order = 2)]
public class SpawnData : ScriptableObject
{
    public GameObject Prefab;
    public int Amount;
    public int Interval;
}
