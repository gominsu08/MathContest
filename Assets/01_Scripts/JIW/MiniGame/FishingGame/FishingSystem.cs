using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class FishingSystem : MiniGames
{
    [Header("FishingGameSetting")] 
    [SerializeField] private int answerCount;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    [SerializeField] private FishingRod _fishingRod;
    [SerializeField] private AnswerFish fishPrefab;
    
        
    protected override void GameEnter()
    {
        base.GameEnter();
        for (int i = 0; i < answerCount; i++)
        {
            var answerFish = Instantiate(fishPrefab);
            answerFish.Init("문제");
            answerFish.transform.position = new Vector3(Random.Range(minSize, maxSize), 0.4f);
        }
    }

    public override void GameExit()
    {
        base.GameExit();
    }
}
