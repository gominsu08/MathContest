using System;
using UnityEngine;

/// <summary>
/// 유닛 업그레이드 관련 정보 SO
/// </summary>
[CreateAssetMenu(menuName = "SO/Unit/Data")]
public class UnitUpgradeData : ScriptableObject
{
    public Sprite sprite;//유닛 스프라이트
    public String name; // 이름
    public int level=1;
    public int cost;
    public string poolName;
    public float _spawnCoolTime;
    
    public UnitDataSO unitData;
    public int index; // 유닛 인덱스
    
    public EmptyPieceManager emptyManagerPrefab;
    public EmptyPieceManager emptyManager;
}
