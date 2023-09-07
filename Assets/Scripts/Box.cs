using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public static Box instance;

    [Header("Monster Cup")]
    public Monster baseMonster;
    public MonsterFactorySO monsterFactoryData;


    private MonsterFactory monsterCup;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        monsterCup = this.gameObject.AddComponent<MonsterFactory>();
        monsterCup.factoryData = monsterFactoryData;
    }
}
