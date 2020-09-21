using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    public string UnitName;
    public string UnitDescription;
    public float HP;
    public float MaxHP;
    public float Tick;
    public float TickRate;

    public int BuildCost;
    public int Gold;

    public void Initialize()
    {
        HP = MaxHP;
    }
}
