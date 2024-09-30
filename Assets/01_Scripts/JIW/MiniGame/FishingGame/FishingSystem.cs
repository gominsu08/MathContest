using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishingSystem : MiniGames
{
    [Header("FishingGameSetting")] 
    [SerializeField] private FishingRod _fishingRod;
    
        
    protected override void GameEnter()
    {
        base.GameEnter();
        
    }

    public override void GameExit()
    {
        base.GameExit();
    }
}
