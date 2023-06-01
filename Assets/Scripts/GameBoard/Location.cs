using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : GameTile
{
    [SerializeField] int cluesAtLocation;
    [SerializeField] bool isUnstable;
    [SerializeField] bool hasOpenGate;
    [SerializeField] bool isSealed;
    [SerializeField] bool hasLocationAbility;

    public Location()
    {
        cluesAtLocation = 0;
    }
    private void Start()
    {
        tileText.text = tileName;
        HideUI();
    }
    public bool GetStability()
    {
        return isUnstable;
    }

    public bool GetSealed()
    {
        return isSealed;
    }

    public bool GetOpenGate()
    {
        return hasOpenGate;
    }

    public void AddToken()
    {
        cluesAtLocation++;
    }

    public int GetTokens()
    {
        return cluesAtLocation;
    }

    public void ResetTokens()
    {
        cluesAtLocation = 0;
    }
}

