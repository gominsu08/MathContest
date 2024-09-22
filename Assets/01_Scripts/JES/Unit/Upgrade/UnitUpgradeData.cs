using System;
using UnityEngine;

/// <summary>
/// 유닛 업그레이드 관련 정보 SO
/// </summary>
[CreateAssetMenu(menuName = "SO/Upgrade/Data")]
public class UnitUpgradeData : ScriptableObject
{
    public Sprite sprite;//유닛 스프라이트
    public String name; // 이름
    public int index; // 유닛 인덱스
    public int level=1;
    public UnitDataSO unitData;
    public EmptyPieceManager emptyManagerPrefab;
    public EmptyPieceManager emptyManager;
}
