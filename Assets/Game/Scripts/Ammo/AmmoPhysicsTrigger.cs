using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPhysicsTrigger : AmmoBase
{
    private int _targetLayer;

    public override void Initialize(UnitBase targetUnitBase, WeaponBase weaponBaseSource)
    {
        base.Initialize(targetUnitBase, weaponBaseSource);
        _targetLayer = targetUnitBase.gameObject.layer;
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);

        if(collider.gameObject.layer == _targetLayer)
        {
            var otherUnitBase = collider.GetComponent<UnitBase>();
            if(otherUnitBase == _targetUnitBase)
            {
                otherUnitBase.SetDamage(_weaponBaseSource.DamageList);
                HandleHit();
            }
        }
    }
}
