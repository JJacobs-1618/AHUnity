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

    public GameObject GetLocation(string location)
    {
        GameObject retVal = null;
        foreach(GameObject go in locations)
        {
            if (location == go.GetComponent<Location>().GetName())
            {
                retVal = go;
                break; ;
            }
        }
        return retVal;
    }

    public List<GameTile> GetLocationsInRange(GameTile starting, int movementPoints)
    {
        List<GameTile> retVal = new List<GameTile>();
        retVal.Add(starting);

        for(int i = 0; i < movementPoints; i++)
        {
            int retValCount = retVal.Count;
            for(int j = 0; j < retValCount; j++)
            {
                foreach (GameTile tile in retVal[j].GetConnectedLocations())
                {
                    if (!retVal.Contains(tile)) retVal.Add(tile);
                }
            }
        }

        return retVal;
    }
}
