using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class FishingUI : MonoBehaviour
{
    [SerializeField] private FishingRod fishingRod;

    private Image _gayg;


    private void Awake()
    {
        _gayg = transform.Find("Gayg").GetComponent<Image>();
    }

    private void Start()
    {
        fishingRod._force.OnValueChanged += HandleValueChage;
    }

    private void HandleValueChage(float prev, float next)
    {
        _gayg.fillAmount = (next - fishingRod._minForce) / (fishingRod._maxForce - fishingRod._minForce);
    }
}
