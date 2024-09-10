using UnityEngine;


/// <summary>
/// 재료 주 컴포넌트
/// </summary>
public class Resource : MonoBehaviour
{
    public NotifyValue<int> count = new NotifyValue<int>();//재료 개수 ui 갱신을 위한 노티파이
    
    private ResouceUI _uiCompo;
    public ResourceDataSO resourceData;
    
    public void Initalized(ResourceDataSO data)
    {
        count.Value = data.count;
        
        _uiCompo = GetComponentInChildren<ResouceUI>();
        _uiCompo.Initialize(this);
        
        resourceData = data;
    }
}