using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;

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
        var a = Instantiate(fishPrefab);
        a.Init(answer);
        for (int i = 0; i < answerCount; i++)
        {
            var answerFish = Instantiate(fishPrefab);
            int random = Random.Range(0, unAnswer.Count);
            string str = unAnswer[random];
            unAnswer.RemoveAt(random);
            answerFish.Init(str);
            answerFish.transform.position = new Vector3(Random.Range(minSize, maxSize), 0.4f);
        }
    }
}
