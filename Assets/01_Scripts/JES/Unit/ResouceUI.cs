using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 재료 아이템 Ui 총관리
/// </summary>
public class ResouceUI : MonoBehaviour
{
    private Image _imageCompo;
    private TextMeshProUGUI _countText;

    private Color _hardColor = new Color(255, 255, 255, 255);
    private Color _softColor = new Color(90, 90, 90, 255);
    public void Initialize(Resource resouce)
    {
        _imageCompo = GetComponentInChildren<Image>();
        _countText = GetComponentInChildren<TextMeshProUGUI>();

        resouce.count.OnValueChanged += HandleCountChangeEvent;
        HandleCountChangeEvent(0, resouce.count.Value);
        
        _imageCompo.sprite = resouce.resourceData.sprite;
    }

    private void HandleCountChangeEvent(int prev, int next)
    {
        _countText.text = $"{next}";
        
        if (next <= 0)
            _imageCompo.color = _hardColor;
        else
            _imageCompo.color = _softColor;
    }
}