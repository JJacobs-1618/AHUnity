using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class FactorySO : ScriptableObject
{
    public List<ScriptableObject> prefabs = new();
}
