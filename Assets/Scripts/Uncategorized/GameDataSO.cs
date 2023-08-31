using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public abstract class GameDataSO : ScriptableObject
{
    public string SavePath = "Assets/TestingFolder/Saves/newgametest.sos";
    [SerializeField] private DateTime _createdDate;
    [SerializeField] private DateTime _lastSavedDate;
    [SerializeField] private List<InvestigatorSO> _investigators;
    [SerializeField] private int _currentRound;

    private void Awake()
    {
        _createdDate = DateTime.Now;        
        //AssetDatabase.CreateAsset(this, SavePath);
    }

    public DateTime GetDateCreated
    {
        get { return _createdDate; }
    }

    public DateTime LastSavedDate
    {
        get { return _lastSavedDate; }
        set { _lastSavedDate = value; }
    }

    public List<InvestigatorSO> Investigators
    {
        get { return _investigators; }
    }

    public int CurrentRound
    {
        get { return _currentRound; }
        set { _currentRound = value; }
    }
}
