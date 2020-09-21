using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBase : MonoBehaviour
{
    [SerializeField] protected LayerMask _backgroundHitLayerMask;

    protected Transform _transform;
    protected UnitBase _targetUnitBase;
    protected WeaponBase _weaponBaseSource;

    private void Awake()
    {
        _transform = transform;
    }

    public virtual void Initialize(UnitBase targetUnitBase, WeaponBase weaponBaseSource) 
    {
        _targetUnitBase = targetUnitBase;
        _weaponBaseSource = weaponBaseSource;
    }

    public virtual void HandleHit()
    {
        _weaponBaseSource.HandleAmmoDestroy();
        Destroy(gameObject);
    }

    public virtual void HandleDestory()
    {
        _weaponBaseSource.HandleAmmoDestroy();
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if(((1 << collider.gameObject.layer) & _backgroundHitLayerMask) != 0)
        {
            HandleDestory();
        }
    }
}
