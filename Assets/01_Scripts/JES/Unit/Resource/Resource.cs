using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// 재료 주 컴포넌트
/// </summary>
public class Resource : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public NotifyValue<int> count = new NotifyValue<int>();//재료 개수 ui 갱신을 위한 노티파이
    
    private ResourceUI _uiCompo;
    public ResourceDataSO resourceData;

    public void Initalized(ResourceDataSO data)
    {
        resourceData = data;
        count.Value = data.count;
        
        _uiCompo = GetComponentInChildren<ResourceUI>();
        _uiCompo.Initialize(this);
        
        GetComponent<Image>().sprite = data.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ResourceManager.Instance.EnterPointer(resourceData.type);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResourceManager.Instance.ExitPointer();
    }
}