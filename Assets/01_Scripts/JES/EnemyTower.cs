using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyTower : MonoBehaviour
{
    [SerializeField] private StageDataSO _stageData;
    private StageDataSO _currentStageData;

    [SerializeField] private float _coolMin=1.5f, _coolMax=3f;
    private float _coolTime;
    private float _lastSpawnTime;
    
    private bool _isSpawning = false;

    private Health _healthCompo;
    private void Awake()
    {
        _currentStageData = Instantiate(_stageData);
        _healthCompo = GetComponent<Health>();
        _healthCompo.Initialize(_currentStageData.enemyTowerHP);
        
        
        _coolTime = Random.Range(_coolMin, _coolMax);
        _isSpawning = true;
    }
    private void Update()
    {
        if(!_isSpawning) return;

        SpawnTry();
    }

    private IEnumerator BossSpawn()
    {
        while (true)
        {
            if (_currentStageData.bossCount > 0)
            {
                Agent boss = PoolManager.Instance.Pop("Boss") as Agent;
                boss.transform.position = transform.position;
                _currentStageData.bossCount--;
                
                yield return new WaitForSeconds(Random.Range(_coolMin, _coolMax));
            }
            else
            {
                break;
            }
        }
    }
    private void SpawnTry()
    {
        if (_lastSpawnTime + _coolTime < Time.time)
        {
            string enemyName = _currentStageData.RandomEnemySpawn(50, 20);

            if (enemyName == null)
            {
                _isSpawning = false;
                StartCoroutine(BossSpawn());
                return;
            }

            Agent enemy =  PoolManager.Instance.Pop(enemyName) as Agent;
            enemy.transform.position = transform.position;
            _lastSpawnTime = Time.time;
            _coolTime = Random.Range(_coolMin, _coolMax);
        }
    }

    public void TowerBreak(bool isEnemy)
    {
        CombatManager.Instance.GameEnd = true;
        StopAllCoroutines();
        if (isEnemy)
        {
            //승리 처리
        }
        else
        {
            //패배 처리
        }
    }
}
