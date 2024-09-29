using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class SeaControll : MonoBehaviour
{
    [Header("Setting")] [SerializeField] private float _horizonSpeed;

    private BuoyancyEffector2D _effector2D;

    private void Awake()
    {
        _effector2D = GetComponent<BuoyancyEffector2D>();
    }

    private void Start()
    {
        DOTween.To(() => _effector2D.surfaceLevel, x => _effector2D.surfaceLevel = x,
            _horizonSpeed, 1.25f).SetEase(Ease.InBack).SetLoops(-1, LoopType.Yoyo);
    }
}