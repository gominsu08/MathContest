using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class CamControll : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCam;
    [SerializeField] private Tower _tower;

    private void Awake()
    {
        _virtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        _tower.OnTowerClickEvent += OnChangeCamera;
    }

    private void OnDisable()
    {
        _tower.OnTowerClickEvent -= OnChangeCamera;
    }

    public void OnChangeCamera(int index)
    {
        _virtualCam.Follow = _tower._towerPoints[index];
    }
}
