using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Threading.Tasks;

public class MemoShortcutkey : MonoBehaviour
{
    private Memo _memo;

    private void Awake()
    {
        _memo = GetComponent<Memo>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            if (Input.GetKeyDown(KeyCode.Y))
            {
                if (_memo.lineList.Count > 0)
                    DestroyLine(_memo.lineList.Last());
                
            }
    }

    private void DestroyLine(LineRenderer line)
    {
        _memo.lineList.Remove(line);
        var data = line;
        Destroy(data.gameObject);
    }

    // private async void DestroyLine(LineRenderer line)
    // {
    //     _memo.lineList.Remove(line);
    //     var data = line;
    //     await Task.Delay(50);// 1000 = 1초
    //     Destroy(data.gameObject);
    // }
}
