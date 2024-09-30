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

    private bool _isCharging;
    public bool isFire;

    private Tweener _forceTweener;

    public Transform _firePos;

    private void Awake()
    {
        _firePos = transform.Find("FirePos");
        _force = new NotifyValue<float>();
        _isCharging = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFire)
        {
            StartSetForce();
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isFire)
        {
            EndSetForce();
            BobberFire(_force.Value);
        }
    }

    private void StartSetForce()
    {
        _force.Value = _minForce;
        _forceTweener = DOTween.To(() => _force.Value, x => _force.Value = x, _maxForce, 0.75f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void EndSetForce()
    {
        _forceTweener.Kill();
        _isCharging = true;
    }

    private void BobberFire(float force)
    {
        if (!_isCharging) return; 
        
        Bobber bobber = Instantiate(_bobberPrefab);
        bobber.transform.position = _firePos.position;
        
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bobber.InitAndFire(dir.normalized,this, force);
        _force.Value = _minForce;
        
        _isCharging = false;
        isFire = true;
    }

}
