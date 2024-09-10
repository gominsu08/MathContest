using System;
using UnityEngine;

/// <summary>
/// 재료 조각 클래스
/// </summary>
public class Piece : MonoBehaviour
{
    private Vector3 MousePos;
    
    public void Initialize(Sprite sprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    private void Update()
    {
        InputMouse();

        transform.position = MousePos;
    }

    private void InputMouse()
    {
        Vector3 inputPos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(inputPos);
    }
}