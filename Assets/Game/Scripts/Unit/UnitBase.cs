using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public Status Status;
    public WeaponBase Weapon;
    public Transform WeaponTransform;
    public bool IsAlive = true;
    public Collider HitCollider;

    public virtual void Initialize() { }

    public virtual void SetDamage(List<Damage> damageList) { }

    public virtual void HandleDeath() { }

    public virtual void HandleSpawn() => Initialize();

    public virtual void Attack(UnitBase targetUnitBase) { }

    public virtual Vector3 GetCenterPosition()
    {
        if(HitCollider != null)
        {
            return HitCollider.bounds.center;
        }
        return transform.position;
    }
}
