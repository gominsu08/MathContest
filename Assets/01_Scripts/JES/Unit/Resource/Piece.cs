using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 재료 조각 클래스
/// </summary>
public class Piece : MonoBehaviour
{ 
    private Vector2 MousePos;
    public RectTransform uiElement;
    public void Initialize(Sprite sprite)
    {
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = sprite;
        
        Image image = GetComponent<Image>();
        image.sprite = sprite;
    }

    private void Update()
    {
        InputMouse();

        uiElement.position = MousePos;
    }

    private void InputMouse()
    {
        Vector2 inputPos = Input.mousePosition;
        MousePos = inputPos;
        //MousePos = Camera.main.ScreenToWorldPoint(inputPos);
    }
}