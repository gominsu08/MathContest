using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Unit/Combat/Data")]
public class UnitDataSO : ScriptableObject
{
    public int damage;
    public int health;
    public float speed;
    public void UnitUpgrade()
    {
        damage +=5;
        health +=5;
    }

    public void EnemyUpgrade()
    {
        damage += 10;
        health += 30;
    }
}
