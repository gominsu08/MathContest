using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUpgrade : MonoBehaviour
{
    public UnitUpgradeData unitData;



    public void Initalize(UpgradeManager manager, UnitUpgradeData data)
    {
        manager.OnChangeEvent += HandleChangeEvent;
        unitData = data;
    }

    private void HandleChangeEvent(int index, bool _isRight)
    {
        //내꺼랑 인덱스 같으면 키고 아니면 끄는 작업
    }
}
