using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    public T objectBase;
    public FactorySO factoryData;

    public T GetNewInstance()
    {
        ScriptableObject data = factoryData.prefabs[UnityEngine.Random.Range(0, factoryData.prefabs.Count)];
        return Instantiate(CreateObject(objectBase, data));
    }
   /* public T GetNewInstanceOf(string seek)
    {
        
    }*/

    public abstract T CreateObject(T baseObj, ScriptableObject data);
}