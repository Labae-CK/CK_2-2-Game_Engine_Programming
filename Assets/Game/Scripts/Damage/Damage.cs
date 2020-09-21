using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage
{
    public enum DamageType { Physical, Fire, Ice };
    public DamageType Type;
    public float Amount;
}
