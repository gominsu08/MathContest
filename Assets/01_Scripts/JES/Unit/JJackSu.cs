using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJackSu : PlayerUnit
{
    [SerializeField] private Transform muzzle;
    public override void Attack()
    {
        Arrow arrow = PoolManager.Instance.Pop("Arrow") as Arrow;
        arrow.Initalize(muzzle,_damage);
    }
}
