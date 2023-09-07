using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateFactory : GenericFactory<Gate>
{
    public static GateFactory instance;

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

    public override Gate CreateObject(Gate baseObj, ScriptableObject data)
    {
        baseObj.data = (GateSO)data;
        return baseObj;
    }
}
