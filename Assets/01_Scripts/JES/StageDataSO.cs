using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/StageData")]
public class StageDataSO : ScriptableObject
{
    public int enemyTowerHP, pcTowerHP;
    
    public int enemy1Count;
    public int enemy2Count;
    public int enemy3Count;

    public int bossCount=1;

    public List<UnitDataSO> datas;
    
    /// <summary>
    /// 스테이지 넘어갈때 한번씩 호출
    /// </summary>
    /// <param name="현재 스테이지 숫자 입력"></param>
    public void CountSet(int stageNumber)
    {
        enemy1Count += 3;
        enemy2Count += 3;
        enemy3Count += 1;
        
        if (stageNumber % 10 == 0)
        {
            bossCount += 1;
        }
        EnemyDataSet(stageNumber);
    }
    private void EnemyDataSet(int stageNumber)
    {
        if (stageNumber % 5 == 0)
        {
            enemyTowerHP += 500;
            pcTowerHP += 50;
            foreach (var value in datas)
            {
                value.EnemyUpgrade();
            }
        }
    }

    public string RandomEnemySpawn(int enemy1Pro, int enemy2Pro)
    {
        int num = Random.Range(0, 101);

        if (num >= enemy1Pro)
        {
            return EnemyCountCheck();
        }
        return num >= enemy2Pro ? EnemyCountCheck(false) : EnemyCountCheck(false, false);
    }
    private string EnemyCountCheck(bool enemy1 = true,bool enemy2 = true)
    {
        if (enemy1 && enemy1Count > 0)
        {
            enemy1Count--;
            return "Enemy1";
        }
        if (enemy2 && enemy2Count > 0)
        {
            enemy2Count--;
            return "Enemy2";
        }
        if (enemy3Count > 0)
        {
            enemy3Count--;
            return "Enemy3";
        }
        
        if (enemy1 && enemy2)
        {
            return null;
        }    
        
        if (enemy1Count > 0)
        {
            enemy1Count--;
            return "Enemy1";
        }

        if (enemy2Count <= 0) return null;
        
        enemy2Count--;
        return "Enemy2";
    }
    
    
}
