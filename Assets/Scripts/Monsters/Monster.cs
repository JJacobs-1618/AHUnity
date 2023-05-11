using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] string monsterName;
    [SerializeField] string flavorText;
    [SerializeField] MonsterStats stats;
    [SerializeField] MonsterController controller;

    public Monster()
    {
        monsterName = "Unset";
        flavorText = "Unset";
    }

    public MonsterStats GetStats()
    {
        return stats;
    }

    public MonsterController GetController()
    {
        return controller;
    }
}
