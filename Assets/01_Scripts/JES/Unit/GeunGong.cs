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
        bomb.Initalize(_targetTrm);
        
        bombTrm.DOLocalMove(new Vector2(-0.16f,-0.56f),0.1f).SetLoops(2, LoopType.Yoyo);
    }
}