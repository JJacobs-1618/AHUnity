using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : GenericFactory<Monster>
{
    public static MonsterFactory instance;

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

    public override Monster CreateObject(Monster baseObj, ScriptableObject data)
    {
        baseObj.data = (MonsterSO)data;
        return baseObj;
    }
}
