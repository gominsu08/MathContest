using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CombatUnitData : MonoSingleton<CombatUnitData>
{
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private GameObject _coolPanel;
    [SerializeField] private Image _cooldownBar;
    private float _cooldownTime;
    
    private UnitUpgradeData _unitData;
    private CombatManager _manager;
    private Vector3 _towerPosition;

    private float _lastSpawnTime;
    private bool _isSpawn=false;
    public void Initialize(UnitUpgradeData unitData, CombatManager manager,Vector3 towerPosition)
    {
        _unitData = unitData;
        _manager = manager;
        
        _costText.text = _unitData.cost.ToString();
        _iconImage.sprite = _unitData.sprite;
        _cooldownTime = _unitData._spawnCoolTime;
        _towerPosition = towerPosition;
    }
    
    
    public void SpanwBtnClicked()
    {
        if (_manager.CoinCheck(_unitData.cost)&&!_isSpawn)
        {
            Agent unit = PoolManager.Instance.Pop(_unitData.poolName) as Agent;
            unit.transform.position = _towerPosition;
            CoolStart();
        }
    }

    private void Update()
    {
        if (_lastSpawnTime + _cooldownTime < Time.time && _isSpawn)
        {
            _isSpawn = false;
            _coolPanel.SetActive(false);
        }
    }

    private void CoolStart()
    {
        _coolPanel.SetActive(true);
        _isSpawn = true;
        _cooldownBar.fillAmount = 0;
        _cooldownBar.DOFillAmount(1, _cooldownTime).SetEase(Ease.Linear);
        _lastSpawnTime = Time.time;
    }
}