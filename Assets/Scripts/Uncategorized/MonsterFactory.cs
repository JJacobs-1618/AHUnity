using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : GenericFactory<Monster>
{
    public override Monster CreateObject(Monster baseObj, ScriptableObject data)
    {
        baseObj.data = (MonsterSO)data;
        return baseObj;
    }
}
