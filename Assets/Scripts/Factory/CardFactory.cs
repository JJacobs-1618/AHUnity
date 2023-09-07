using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : GenericFactory<Card>
{
    public static CardFactory instance;

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
    public override Card CreateObject(Card baseObj, ScriptableObject data)
    {
        throw new System.NotImplementedException();
    }
}
