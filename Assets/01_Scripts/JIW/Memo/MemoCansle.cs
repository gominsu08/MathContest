using System;
using UnityEngine;
using DG.Tweening;

public class MemoCansle : MonoBehaviour
{
    private Memo _memo;

    private void Awake()
    {
        _memo = GetComponentInParent<Memo>();
    }

    private void OnMouseDown()
    {
        _memo.DeleteAllLine();
        
        _memo.CloseMemo(); 
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
            if(Input.GetKeyDown(KeyCode.Y))
                _memo.DeleteLine();
    }
}
