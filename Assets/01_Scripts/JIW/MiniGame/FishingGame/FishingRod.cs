using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class FishingRod : MonoBehaviour
{
    [SerializeField] private Bobber _bobberPrefab;
    public float _minForce;
    public NotifyValue<float> _force;
    public float _maxForce;

    private Tweener _forceTweener;

    private void Awake()
    {
        _force = new NotifyValue<float>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartSetForce();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            EndSetForce();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
            BobberFire(_force.Value);
    }

    private void StartSetForce()
    {
        _force.Value = _minForce;
        _forceTweener = DOTween.To(() => _force.Value, x => _force = x, _maxForce, 0.75f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void EndSetForce()
    {
        _forceTweener.Kill();
    }

    private void BobberFire(float force)
    {
        Bobber bobber = GameObject.Instantiate(_bobberPrefab,transform.position,Quaternion.identity);
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bobber.InitAndFire(dir.normalized, force);
        _force.Value = _minForce;
    }
}
