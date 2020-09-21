using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : UnitBase
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private Core _core;
    private WaitForSeconds _tickRateWFS;

    private void Start()
    {
        Initialize();
        HandleSpawn();
    }

    public override void Initialize()
    {
        base.Initialize();
        _tickRateWFS = new WaitForSeconds(Status.TickRate);
    }

    public override void HandleSpawn()
    {
        base.HandleSpawn();

        _core = GameManager.Instance.Core;
        Weapon = Instantiate(Weapon);
        Weapon.Initialize(this);
        StartCoroutine(AI());
    }

    public override void Attack(UnitBase targetUnitBase)
    {
        base.Attack(targetUnitBase);

        Weapon.SetTarget(targetUnitBase);
        Weapon.Fire();
    }

    public override void HandleDeath()
    {
        base.HandleDeath();
        Destroy(this.gameObject);
    }

    private IEnumerator AI()
    {
        while (true)
        {
            if(_core != null)
            {
                _navMeshAgent.SetDestination(_core.transform.position);

                if(Vector3.Distance(transform.position, _core.transform.position) < Weapon.Range)
                {
                    Attack(_core);
                }
            }
            else
            {
                _navMeshAgent.isStopped = true;
            }

            yield return _tickRateWFS;
        }
    }
}
