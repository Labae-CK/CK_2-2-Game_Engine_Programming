using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponArrow : WeaponBase
{
    public AnimationCurve Trajectory;

    private int _pointCount = 10;
    private Vector3[] _pathPoints;
    private Tween _currentTween;

    public override void Initialize(UnitBase parentUnitBase)
    {
        base.Initialize(parentUnitBase);
        _pathPoints = new Vector3[_pointCount];
    }

    public override void Fire()
    {
        base.Fire();

        GameObject projectile = Instantiate(Ammo.gameObject);
        projectile.transform.position = _unitBase.WeaponTransform.position;
        AmmoPhysicsTrigger ammoClass = projectile.GetComponent<AmmoPhysicsTrigger>();
        ammoClass.Initialize(_currentTargetUnit, this);

        Vector3 dir = _currentTargetUnit.GetCenterPosition() - projectile.transform.position;
        Vector3 ratio = dir / (_pointCount - 1);
        for (int i = 0; i < _pointCount; i++)
        {
            _pathPoints[i] = projectile.transform.position + i * ratio;
            _pathPoints[i].y += Trajectory.Evaluate((float)i / _pointCount);
        }

        projectile.transform.LookAt(_pathPoints[1]);

        Path path = new Path(DG.Tweening.PathType.CatmullRom, _pathPoints, 1);
        _currentTween = projectile.transform.DOPath(path, 5).SetLookAt(0.01f).SetSpeedBased(true).OnComplete(() => OnAmmoReachedDestination(ammoClass));
    }

    private void OnAmmoReachedDestination(AmmoPhysicsTrigger ammoClass)
    {
        ammoClass.HandleDestory();
    }

    public override void HandleAmmoDestroy()
    {
        base.HandleAmmoDestroy();

        if(_currentTween != null)
        {
            _currentTween.Kill();
        }
    }
}
