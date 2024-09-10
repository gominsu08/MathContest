using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 재료 아이템 종류 타입
/// </summary>
public enum ResourceType
{
    a,b,c,x,y,pie,squ,l,r,number
}
/// <summary>
/// 재료 아이템 정보 SO
/// </summary>
[CreateAssetMenu(menuName = "SO/Resource/Data")]
public class ResourceDataSO : ScriptableObject
{
    public Sprite sprite; // 아이템 스프라이트
    public ResourceType type; // 아이템 타입
    public int count; //아이템 개수
}
