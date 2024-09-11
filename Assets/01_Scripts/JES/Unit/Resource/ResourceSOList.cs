using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 리소스 SO 리스트
/// </summary>
[CreateAssetMenu(menuName = "SO/Resource/List")]
public class ResourceSOList : ScriptableObject
{
    public List<ResourceDataSO> dataList;
}