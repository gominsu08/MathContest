using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유닛 업그레이드 관련 정보 SO
/// </summary>
[CreateAssetMenu(menuName = "SO/Upgrade/Data")]
public class UnitUpgradeData : ScriptableObject
{
    public Sprite sprite;//유닛 스프라이트
    public String name; // 이름
}
