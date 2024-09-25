using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 재료 아이템 Ui 총관리
/// </summary>
public class ResourceUI : MonoBehaviour
{
    private TextMeshProUGUI _countText;

    public void Initialize(Resource resouce)
    {
        _countText = GetComponentInChildren<TextMeshProUGUI>();

        resouce.count.OnValueChanged += HandleCountChangeEvent;
        HandleCountChangeEvent(0, resouce.count.Value);
    }

    private void HandleCountChangeEvent(int prev, int next)
    {
        _countText.text = $"{next}";
    }
}