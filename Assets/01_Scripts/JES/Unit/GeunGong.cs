using DG.Tweening;
using UnityEngine;

public class GeunGong : PlayerUnit
{
    [SerializeField] private Transform bombTrm;
    [SerializeField] private float deg=50f;
    [SerializeField] private string _bombPoolname;
    public override void Attack()
    {
        Bomb bomb = PoolManager.Instance.Pop(_bombPoolname) as Bomb;
        bomb.transform.position = bombTrm.position;
        bomb.Initalize(_targetTrm.position,_damage);
    }
}