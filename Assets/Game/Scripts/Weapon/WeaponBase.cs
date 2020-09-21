using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponBase", menuName ="Data/WeaponBaseData", order = 1)]
public class WeaponBase : ScriptableObject
{
    public float Range;
    public List<Damage> DamageList;
    public AmmoBase Ammo;

    protected UnitBase _unitBase;
    protected UnitBase _currentTargetUnit;

    public virtual void Initialize(UnitBase parentUnitBase) => _unitBase = parentUnitBase;

    public virtual void SetTarget(UnitBase targetUnitBase) => _currentTargetUnit = targetUnitBase;

    public virtual void Fire() { }

    public virtual void Reload() { }

    public virtual void UpdateWeapon() { }

    public virtual void HandleAmmoDestroy()
    {

    }
}
