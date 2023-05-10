using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public static GameBoard instance;

    [SerializeField] List<GameObject> locations;
    [SerializeField] List<GameObject> streets;
    [SerializeField] List<GameObject> otherWorlds;

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

    public void InitGameBoard()
    {
        SetClueTokens();
    }

    private void SetClueTokens()
    {
        foreach (GameObject go in locations)
        {
            Location l = go.GetComponent<Location>();
            if (!l.GetStability()) l.AddToken();
        }
    }

    public Vector3 GetLocation(string location)
    {
        Vector3 returnVec = new Vector3();
        foreach(GameObject go in locations)
        {
            Location l = go.GetComponent<Location>();
            if (l.GetName() == location)
                returnVec = go.transform.position;
        }
        return returnVec;
    }
}
