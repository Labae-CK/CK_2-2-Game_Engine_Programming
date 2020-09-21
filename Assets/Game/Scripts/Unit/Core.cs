using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : UnitBase
{
    public override void SetDamage(List<Damage> damageList)
    {
        base.SetDamage(damageList);

        for (int i = 0; i < damageList.Count; i++)
        {
            Damage dmg = damageList[i];
            Status.HP -= dmg.Amount;
            if (Status.HP <= 0)
            {
                HandleDeath();
            }
        }
    }

    public override void HandleDeath()
    {
        base.HandleDeath();
        Destroy(this.gameObject);
    }
}
